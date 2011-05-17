using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BK_Controller;

namespace BK_GUI
{
    public partial class FrmLogin : Form
    {
        BrugerKlient brugerklient;
		bool hashedKodeord;

        public FrmLogin()
        {
            InitializeComponent();
			brugerklient = new BrugerKlient();
			string brugernavn, password;
			bool filLoaded = brugerklient.hentLoginData(out brugernavn, out password);
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
					chkHuskKodeord.Checked = true;
				}
				else
					hashedKodeord = false;
			}
			else
				hashedKodeord = false;
        }

		//Lavet af Denny
        private void lblOpretBruger_Click(object sender, EventArgs e)
        {
            FrmOpretBruger opretbruger = new FrmOpretBruger();
            this.Hide();
            opretbruger.ShowDialog();
            this.Show();
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
			long brugerID = brugerklient.Login(txtBrugernavn.Text, txtKodeord.Text, hashedKodeord);

            if (brugerID > 0)    //login succesfuldt
            {
                FrmLoginKampagneValg loginkampagnevalg = new FrmLoginKampagneValg(brugerklient);
                this.Hide();
				if (chkHuskBrugernavn.Checked && chkHuskKodeord.Checked)
					brugerklient.GemLoginData(txtBrugernavn.Text, txtKodeord.Text);
				else if (chkHuskBrugernavn.Checked)
					brugerklient.GemLoginData(txtBrugernavn.Text);
                loginkampagnevalg.ShowDialog();
                this.Close();
            }
			else if (brugerID == -1) //brugerID sættes til -1 på DBfacaden hvis der sker en fejl der
			{
				MessageBox.Show("Der skete en fejl ved login", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKodeord.Text = "";
			}
            else
            {
				MessageBox.Show("Brugernavn og kodeord passer ikke sammen", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeord.Text = "";
            }

        }

		private void chkHuskBrugernavn_CheckedChanged(object sender, EventArgs e)
		{
			chkHuskKodeord.Enabled = chkHuskBrugernavn.Checked;
			if (!chkHuskBrugernavn.Checked)
				chkHuskKodeord.Checked = false;
		}

		private void chkHuskKodeord_CheckedChanged(object sender, EventArgs e)
		{
			if (chkHuskKodeord.Checked)
				MessageBox.Show("Brug kun denne funktion på din private computer", "Vigtigt", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void txtKodeord_TextChanged(object sender, EventArgs e)
		{
			hashedKodeord = false;
		}
    }
}
