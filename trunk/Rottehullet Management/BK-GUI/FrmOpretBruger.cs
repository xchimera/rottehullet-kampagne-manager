using System;
using System.Windows.Forms;
using BK_Controller;

namespace BK_GUI
{
    public partial class FrmOpretBruger : Form
    {
        private readonly BrugerKlient brugerklient;

        public FrmOpretBruger()
        {
            InitializeComponent();
            brugerklient = new BrugerKlient();
        }

		//Lavet af Denny
        private void btnTilføjBruger_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Convert.ToString(txtMail.Text);
                string kodeord = Convert.ToString(txtKodeord.Text);
                string navn = Convert.ToString(txtNavn.Text);
                string allergi = Convert.ToString(txtAllergi.Text);
                string andet = Convert.ToString(txtAndet.Text);
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
                    veganer = true;
                }

				kodeord = brugerklient.KrypterKodeord(kodeord);

				if (brugerklient.Opretbruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet))
				{
					MessageBox.Show("Brugeren er blevet oprettet", "Bruger Oprettet");
					this.Close();
				}
				else
				{
					MessageBox.Show("Brugeren er ikke blevet oprettet", "Database Fejl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
            }
            catch (FormatException)
            {

                MessageBox.Show("Indtast venligst korrekte værdier.", "Bruger Fejl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

		//Lavet af Denny
        private void btnAnnuller_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
