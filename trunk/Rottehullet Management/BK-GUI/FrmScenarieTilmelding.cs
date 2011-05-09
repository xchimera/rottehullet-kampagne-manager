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
	public partial class FrmScenarieTilmelding : Form
	{
		BrugerKlient brugerKlient;
		long karakterID;
		IScenarie scenarie;

		public FrmScenarieTilmelding(BrugerKlient brugerKlient, long karakterID, IScenarie scenarie)
		{
			InitializeComponent();
			this.brugerKlient = brugerKlient;
			this.karakterID = karakterID;
			this.scenarie = scenarie;

			txtInfo.Text = "Titel: " + scenarie.Titel + Environment.NewLine + Environment.NewLine;
			txtInfo.Text += "Beskrivelse: " + scenarie.Beskrivelse + Environment.NewLine + Environment.NewLine;
			txtInfo.Text += "Sted: " + scenarie.Sted + Environment.NewLine + Environment.NewLine;
			txtInfo.Text += "Pris: " + scenarie.Pris + " kr" + Environment.NewLine + Environment.NewLine;
			txtInfo.Text += "Tidspunkt: kl." + scenarie.Tid.Hour + ":" + scenarie.Tid.Minute + " " + scenarie.Tid.Day + "/" + scenarie.Tid.Month + "-" + scenarie.Tid.Year;

			lblTotaleOvernatninger.Text = "(Ud af " + scenarie.Overnatning +  ")";

			if (scenarie.OvernatningTvungen == true)
			{
				txtOvernatning.Text = scenarie.Overnatning.ToString();
				txtOvernatning.ReadOnly = true;
			}
			if (scenarie.SpisningTvungen == true)
			{
				chkSpisning.Checked = true;
				//chkSpisning.
			}
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnTilmeld_Click(object sender, EventArgs e)
		{
			int overnatninger;
			if (!int.TryParse(txtOvernatning.Text, out overnatninger))
			{
				MessageBox.Show("Antal overnatninger skal være et heltal", "Fejl ved indtastning");
				return;
			}

			if (brugerKlient.TilmeldKarakterTilScenarie(karakterID, scenarie.Id, overnatninger, chkSpisning.Checked))
			{
				this.Close();
			}
			else
			{
				MessageBox.Show("Der skete en fejl under oprettelsen af karakteren", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
