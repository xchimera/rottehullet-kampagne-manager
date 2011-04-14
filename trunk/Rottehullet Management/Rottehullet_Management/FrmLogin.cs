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
            long brugerID = kampagnemanager.Login(txtBrugernavn.Text, txtKodeord.Text);
			List<string[]> kampagner = new List<string[]>();
			if (brugerID == 1)
            {
                FrmAdminSektion adminsektion = new FrmAdminSektion(kampagnemanager);
                this.Hide();
                adminsektion.ShowDialog();
                this.Close();
            }
            else if(brugerID > 0)
            {
				foreach (string[] kampagne in kampagnemanager.GetBrugersKampagneIterator())
				{
					kampagner.Add(kampagne);
				}
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
						MessageBox.Show("Der skete en fejl under adgangen til denne kampagne.");
					}
				}
				else if (kampagner.Count > 1)
				{
					FrmLoginKampagneValg loginKampagneValg = new FrmLoginKampagneValg(kampagnemanager);
					this.Hide();
					loginKampagneValg.ShowDialog();
					this.Close();
				}
				else
				{
					MessageBox.Show("Denne bruger er ikke i en spilledelse");
				}
            }
            else
            {
                MessageBox.Show("Brugernavn eller kodeord passer ikke");
            }
        }
    }
}
