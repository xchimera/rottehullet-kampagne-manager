﻿using System;
using System.Windows.Forms;
using BK_Controller;

namespace BK_GUI
{
    public partial class BK_Klient : Form
    {
        private readonly BrugerKlient brugerklient;

        public BK_Klient()
        {
            InitializeComponent();
            brugerklient = new BrugerKlient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnTilføjBruger_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Convert.ToString(txtMail.Text);
                string kodeord = Convert.ToString(txtKodeord.Text);
                string navn = Convert.ToString(txtNavn.Text);
                DateTime fødselsdag = dtpFødselsdag.Value;
                long tlf = long.Parse(txtTlf.Text);
                long nød_tlf = long.Parse(txtNød_tlf.Text);
                bool vegetar = false;
                bool veganer = false;

                if (chkVegetar.Checked)
                {
                    vegetar = true;
                }
                if (chkVeganer.Checked)
                {
                    vegetar = true;
                    veganer = true;
                }

                brugerklient.Opretbruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);

            }
            catch (FormatException)
            {

                MessageBox.Show("Indtast venligst korrekte værdier.", "Værdi Fejl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }
    }
}