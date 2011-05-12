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
	public partial class FrmOpstartScenarie : Form
	{
		KampagneManager kampagneManager;

		public FrmOpstartScenarie(KampagneManager kampagneManager)
		{
			InitializeComponent();
			this.kampagneManager = kampagneManager;
		}

		//Lavet af René
		private void chkOvernatning_CheckedChanged(object sender, EventArgs e)
		{
			chkOvernatningTvungen.Enabled = chkOvernatning.Checked;
			txtAntalDage.Enabled = chkOvernatning.Checked;
		}

		//Lavet af René
		private void chkSpisning_CheckedChanged(object sender, EventArgs e)
		{
			chkSpisningTvungen.Enabled = chkSpisning.Checked;
		}

		//Lavet af René
		//Inputvalidering lavet af René og Thorbjørn
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

			if (chkOvernatning.Checked)
			{
				if (int.TryParse(txtAntalDage.Text, out overnatning))
				{
					if (overnatning < 1)
						MessageBox.Show("Der skal være mindst en overnatning, når overnatning er valgt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				} 
				else
					MessageBox.Show("Der skal indtastes en antal overnatninger i heltal, når overnatning er valgt");
			}
			else
				overnatning = 0;

			if (kampagneManager.TilføjScenarie(txtNavn.Text, txtBeskrivelse.Text, dtpTid.Value, txtSted.Text, float.Parse(txtPris.Text), overnatning, chkSpisning.Checked, chkSpisningTvungen.Checked, chkOvernatningTvungen.Checked, txtAndetInfo.Text))
				this.Close();
			else
				MessageBox.Show("Der skete en fejl, da databasen skulle behandle data", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
