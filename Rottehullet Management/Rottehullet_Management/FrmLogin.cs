using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using Interfaces;

namespace Rottehullet_Management
{
    public partial class FrmLogin : Form
    {
		KampagneManager kampagnemanager;
		bool hashedKodeord;

        public FrmLogin()
        {
            InitializeComponent();
			kampagnemanager = new KampagneManager();
			string brugernavn, password;
			bool filLoaded = kampagnemanager.hentLoginData(out brugernavn, out password);
			if (filLoaded)
			{
				if (brugernavn != null)
				{
					txtBrugernavn.Text = brugernavn;
					chkHuskBrugernavn.Checked = true;
				}
				if (password != null && password.Length == 32)
				{
					txtKodeord.Text = password;
					hashedKodeord = true;
					chkHuskAdgangskode.Checked = true;
				}
				else
					hashedKodeord = false;
			}
			else
				hashedKodeord = false;
        }

		//Lavet af Søren og Thorbjørn
        private void btnLogin_Click(object sender, EventArgs e)
        {
			//Inputvalidering
			if (txtBrugernavn.Text == "")
			{
				MessageBox.Show("Indtast venligst brugernavn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeord.Text = "";
				return;
			}
			else if (txtKodeord.Text == "")
			{
				MessageBox.Show("Indtast venligst adgangskode", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeord.Text = "";
				return;
			}
			//Checker databasen for brugerens brugerID
            long brugerID = kampagnemanager.Login(txtBrugernavn.Text, txtKodeord.Text, hashedKodeord); //Sender brugerID tilbage og 
			//Admin-brugeren har brugerID 1
			if (brugerID == 1)
            {
                kampagnemanager.HentBrugereTilAdmin();
                FrmAdminSektion adminsektion = new FrmAdminSektion(kampagnemanager);
				this.Hide();
				if (chkHuskBrugernavn.Checked)
					kampagnemanager.GemLoginData(txtBrugernavn.Text);
                adminsektion.ShowDialog();
                this.Close();
            }
            else if(brugerID > 0)
            {
				//Hvis brugeren er med i en enkel kampagne, så hopper vi direkte til den kampagnes side
				if (kampagnemanager.GetAntalKampagner() == 1)
				{
					if (kampagnemanager.HentKampagneInfo())
					{
						FrmHovedside hovedside = new FrmHovedside(kampagnemanager);
						this.Hide();
						if (chkHuskBrugernavn.Checked && chkHuskAdgangskode.Checked)
							kampagnemanager.GemLoginData(txtBrugernavn.Text, txtKodeord.Text);
						else if (chkHuskBrugernavn.Checked)
							kampagnemanager.GemLoginData(txtBrugernavn.Text);
						hovedside.ShowDialog();
						this.Close();
					}
					else
					{
						MessageBox.Show("Der skete en fejl ved indlæsningen af din kampagne", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				//Hvis brugeren er i mere end en kampagne bliver han sent til KampagneValg siden, hvor han kan vælge en kampagne
				else if (kampagnemanager.GetAntalKampagner() > 1)
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
			else if (brugerID == -1) //brugerID sættes til -1 på DBfacaden hvis der sker en fejl der
			{
				MessageBox.Show("Der skete en fejl ved login", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKodeord.Text = "";
			}
            else
            {
				MessageBox.Show("Brugernavn eller kodeord passer ikke", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeord.Text = "";
            }
        }

		private void chkHuskBrugernavn_CheckedChanged(object sender, EventArgs e)
		{
			chkHuskAdgangskode.Enabled = chkHuskBrugernavn.Checked;
			if (!chkHuskBrugernavn.Checked)
				chkHuskAdgangskode.Checked = false;
		}

		private void chkHuskAdgangskode_CheckedChanged(object sender, EventArgs e)
		{
			if (chkHuskAdgangskode.Checked && !hashedKodeord)
				MessageBox.Show("Brug kun denne funktion på din private computer", "Vigtigt", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
    }
}
