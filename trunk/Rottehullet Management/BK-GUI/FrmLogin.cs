using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BK_Controller;

namespace BK_GUI
{
    public partial class FrmLogin : Form
    {
        BrugerKlient brugerklient;
        public FrmLogin()
        {
            InitializeComponent();
            brugerklient = new BrugerKlient();
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
            long brugerID = brugerklient.Login(txtBrugernavn.Text, txtKodeord.Text);

            if (brugerID > 0)    //login succesfuldt
            {
                FrmLoginKampagneValg loginkampagnevalg = new FrmLoginKampagneValg(brugerklient);
                this.Hide();
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
    }
}
