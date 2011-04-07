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
            if(kampagnemanager.Login(txtBrugernavn.Text.ToString(), txtKodeord.Text.ToString()))
            {
                FrmHovedside hovedside = new FrmHovedside(kampagnemanager);
                this.Hide();
                hovedside.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Brugernavn eller kodeord passer ikke");
            }
        }
    }
}
