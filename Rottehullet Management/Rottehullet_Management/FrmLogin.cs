using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;

namespace Rottehullet_Management
{
    public partial class FrmLogin : Form
    {
        KampagneManager kampagnemanager;

        public FrmLogin()
        {
            InitializeComponent();
            kampagnemanager = new KampagneManager();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
			//Inputvalidering
			if (txtBrugernavn.Text == "")
			{
				MessageBox.Show("Indtast venligst brugernavn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if (txtKodeord.Text == "")
			{
				MessageBox.Show("Indtast venligst adgangskode", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			//Checker databasen for brugerens brugerID
            long brugerID = kampagnemanager.Login(txtBrugernavn.Text, txtKodeord.Text);
			List<string[]> kampagner = new List<string[]>();
			//Admin-brugeren har brugerID 1
			if (brugerID == 1)
            {
                FrmAdminSektion adminsektion = new FrmAdminSektion(kampagnemanager);
                this.Hide();
                adminsektion.ShowDialog();
                this.Close();
            }
            else if(brugerID > 0)
            {
				//Følgende laver en liste over kampagner i hvilken brugeren er superbruger eller topbruger
				foreach (string[] kampagne in kampagnemanager.GetBrugersKampagneIterator())
				{
					kampagner.Add(kampagne);
				}
				//Hvis brugeren er med i en enkel kampagne, så hopper vi direkte til den kampagnes side
				if (kampagner.Count == 1)
				{
					if (kampagnemanager.HentKampagneFraDatabase(Convert.ToInt64(kampagner[0][0])))
					{
						FrmHovedside hovedside = new FrmHovedside(kampagner[0][1], kampagnemanager);
						this.Hide();
						hovedside.ShowDialog();
						this.Close();
					}
					else
					{
						MessageBox.Show("Der skete en fejl ved indlæsningen af din kampagne", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				//Hvis brugeren er i mere end en kampagne bliver han sent til KampagneValg siden, hvor han kan vælge en kampagne
				else if (kampagner.Count > 1)
				{
					FrmLoginKampagneValg loginKampagneValg = new FrmLoginKampagneValg(kampagnemanager);
					this.Hide();
					loginKampagneValg.ShowDialog();
					this.Close();
				}
				else
				{
					MessageBox.Show("Denne bruger er ikke i en spilledelse", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
            }
            else
            {
				MessageBox.Show("Brugernavn eller kodeord passer ikke", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
