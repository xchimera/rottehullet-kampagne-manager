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

        private void lblOpretBruger_Click(object sender, EventArgs e)
        {
            FrmOpretBruger opretbruger = new FrmOpretBruger();
            this.Hide();
            opretbruger.ShowDialog();
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            long brugerID = brugerklient.Login(txtBrugernavn.Text, txtKodeord.Text);

            if (brugerID > 0)    //login succesfuldt
            {

            }
            else
            {
                MessageBox.Show("Brugernavn og kodeord passer ikke sammen");
            }

        }
    }
}
