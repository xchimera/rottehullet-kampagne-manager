using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using Interfaces;

namespace Rottehullet_Management
{
	public partial class FrmRetScenarie : Form
	{
		KampagneManager kampagneManager;

		public FrmRetScenarie(KampagneManager kampagneManager, IScenarie scenarie)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();
			txtNavn.Text = scenarie.Titel;
			dtpTid.Value = scenarie.Tid;
			txtSted.Text = scenarie.Sted;
			txtPris.Text = scenarie.Pris.ToString();
			txtBeskrivelse.Text = scenarie.Beskrivelse;
			if (scenarie.Overnatning != 0)
			{
				chkOvernatning.Checked = true;
				chkOvernatningTvungen.Checked = scenarie.OvernatningTvungen;
				txtAntalDage.Text = scenarie.Overnatning.ToString();
			}
			if (scenarie.Spisning)
			{
				chkSpisning.Checked = true;
				chkSpisningTvungen.Checked = scenarie.SpisningTvungen;
			}
			txtAndetInfo.Text = scenarie.AndetInfo;
		}

		private void chkOvernatning_CheckedChanged(object sender, EventArgs e)
		{
			chkOvernatningTvungen.Enabled = chkOvernatning.Checked;
			txtAntalDage.Enabled = chkOvernatning.Checked;
		}

		private void chkSpisning_CheckedChanged(object sender, EventArgs e)
		{
			chkSpisningTvungen.Enabled = chkSpisning.Checked;
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnRet_Click(object sender, EventArgs e)
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
			{
				if (int.TryParse(txtAntalDage.Text, out overnatning))
				{
					if (overnatning < 1)
						MessageBox.Show("Der skal være mindst en overnatning, når overnatning er valgt", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
					MessageBox.Show("Der skal indstates en antal overnatninger i heltal, når overnatning er valgt");
			}
			else
				overnatning = 0;

			if (kampagneManager.RetScenarie(txtNavn.Text, txtBeskrivelse.Text, dtpTid.Value, txtSted.Text, double.Parse(txtPris.Text), overnatning, chkSpisning.Checked, chkSpisningTvungen.Checked, chkOvernatningTvungen.Checked, txtAndetInfo.Text))
				this.Close();
			else
				MessageBox.Show("Der skete en fejl, da databasen skulle behandle data", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
