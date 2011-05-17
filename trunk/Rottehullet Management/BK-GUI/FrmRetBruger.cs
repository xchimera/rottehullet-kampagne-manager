using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BK_Controller;
using Interfaces;

namespace BK_GUI
{
	public partial class FrmRetBruger : Form
	{
		BrugerKlient brugerklient;

		public FrmRetBruger(BrugerKlient brugerklient)
		{
			InitializeComponent();
			this.brugerklient = brugerklient;
			IBruger bruger = brugerklient.Bruger;
			txtNavn.Text = bruger.Navn;
			txtAllergi.Text = bruger.Allergi;
			txtAndet.Text = bruger.Andet;
			dtpFødselsdag.Value = bruger.Fødselsdag;
			txtTlf.Text = bruger.Tlf.ToString();
			txtNød_tlf.Text = bruger.NødTlf.ToString();
			chkVegetar.Checked = bruger.Vegetar;
			chkVeganer.Checked = bruger.Veganer;
		}

		private void btnTilføjBruger_Click(object sender, EventArgs e)
		{
			try
			{
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
				if (brugerklient.RetBruger(navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet))
				{
					MessageBox.Show("Dine brugerinformationer er blevet rettet", "Brugerinfo Rettet");
					this.Close();
				}
				else
				{
					MessageBox.Show("Dine brugerinformationer er ikke blevet rettet", "Database Fejl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (FormatException)
			{

				MessageBox.Show("Indtast venligst korrekte værdier.", "Bruger Fejl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnKodeord_Click(object sender, EventArgs e)
		{

		}

        private void chkVegetar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVegetar.Checked)
            {
                chkVeganer.Enabled = false;
            }
            else if (!chkVegetar.Checked)
            {
                chkVeganer.Enabled = true;
            }
        }

        private void chkVeganer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVeganer.Checked)
            {
                chkVegetar.Enabled = false;
            }
            else if (!chkVeganer.Checked)
            {
                chkVegetar.Enabled = true;
            }
        }
	}
}
