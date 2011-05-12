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

		//Lavet af René
		public FrmRetScenarie(KampagneManager kampagneManager, IScenarie scenarie)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();
			txtNavn.Text = scenarie.Titel;
			dtpTid.Value = scenarie.Tid;
			txtSted.Text = scenarie.Sted;
			txtPris.Text = PrisTilGUI(scenarie.Pris);
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

		//Denne metode konverterer pris i form af et tal til en string som passer i
		//masken på GUIen
		//Lavet af Thorbjørn
		private string PrisTilGUI(double prisfloat)
		{
			string pris = prisfloat.ToString();
			//Sæt mellemrum ind foran, så der er 5 symboler før kommaet
			double i = prisfloat;
			if (i > 0)
			{
				while (i < 10000)
				{
					pris = "0" + pris;
					i *= 10;
				}
			}
			else
			{
				pris = "0000" + pris;
			}
			//Sæt talene efter kommaet ordentligt op
			i = prisfloat % 1;
			int j = 0;
			while (j<2)
			{
				if (i == 0)
				{
					pris = pris + "0";
				}
				i = i*10%1;
				j++;
			}
			
			return pris;
		}

		//Denne metode konverterer et heltal så det passer i en maske af længden "længde"
		//Lavet af Thorbjørn
		private string IntTilMask(int tal, int længde)
		{
			string streng = tal.ToString();
			//Sæt mellemrum ind foran, så der er 5 symboler før kommaet
			int i = tal;
			if (i > 0)
			{
				while (i < (10^længde))
				{
					streng = "0" + streng;
					i *= 10;
				}
			}
			else
			{
				for (int j = 0; j < længde-1; j++)
				{
					streng = "0" + streng;
				}
			}
			return streng;
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

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//Lavet af René
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
