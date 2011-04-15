﻿using System;
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

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
