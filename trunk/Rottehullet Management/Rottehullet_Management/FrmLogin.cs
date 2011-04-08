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
			List<string[]> kampagner = new List<string[]>();
            if(kampagnemanager.Login(txtBrugernavn.Text.ToString(), txtKodeord.Text.ToString()))
            {
				foreach (string[] kampagne in kampagnemanager.GetRettigheder())
				{
					kampagner.Add(kampagne);
				}
				if (kampagner.Count == 1)
				{
					FrmHovedside hovedside = new FrmHovedside(Convert.ToInt64(kampagner[0][0]),kampagner[0][1],kampagnemanager);
					this.Hide();
					hovedside.ShowDialog();
					this.Close();
				}
				else if (kampagner.Count > 1)
				{
					FrmLoginKampagneValg loginKampagneValg = new FrmLoginKampagneValg(kampagnemanager, kampagner);
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
