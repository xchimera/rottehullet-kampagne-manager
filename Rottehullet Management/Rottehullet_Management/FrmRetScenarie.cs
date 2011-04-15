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
	public partial class FrmRetScenarie : Form
	{
		KampagneManager kampagneManager;

		public FrmRetScenarie(KampagneManager kampagneManager)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOpret_Click(object sender, EventArgs e)
		{
			int overnatning;

			if (txtNavn.Text == "")
			{
				MessageBox.Show("Scenariet skal have et navn", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (txtSted.Text == "")
			{
				MessageBox.Show("Sted skal være udfyldt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (txtBeskrivelse.Text == "")
			{
				MessageBox.Show("Beskrivelsen skal være udfyldt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (chkOvernatning.Checked)
				overnatning = int.Parse(txtAntalDage.Text);
			else
				overnatning = 0;

			kampagneManager.TilføjScenarie(txtNavn.Text, txtBeskrivelse.Text, dtpTid.Value, txtSted.Text, double.Parse(txtPris.Text), overnatning, chkSpisning.Checked, chkSpisningTvungen.Checked, chkOvernatningTvungen.Checked, txtAndetInfo.Text);
			this.Close();
		}
	}
}
