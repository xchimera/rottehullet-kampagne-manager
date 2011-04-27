using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using Interfaces;
using Enum;

namespace Rottehullet_Management
{
	public partial class FrmAttributter : Form
	{
		KampagneManager kampagneManager;

		public FrmAttributter(KampagneManager kampagneManager)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();
			opdaterListe();
		}

		private void opdaterListe()
		{
			lstAttributter.Items.Clear();
			IEnumerator iterator = kampagneManager.HentAttributter();
			IKampagneAttribut iKampagneAttribut;
			ListViewItem linje;
			iterator.Reset();
			while (iterator.MoveNext())
			{
				iKampagneAttribut = (IKampagneAttribut)iterator.Current;
				linje = new ListViewItem();
				linje.Text = iKampagneAttribut.KampagneAttributID.ToString();
				linje.SubItems.Add(iKampagneAttribut.Navn);
				if (iKampagneAttribut.Type == KampagneAttributType.Combo)
				{
					linje.SubItems.Add("Multiple Choice");
				}
				else if (iKampagneAttribut.Type == KampagneAttributType.Multiline)
				{
					linje.SubItems.Add("Flerlinjet tekstboks");
				}
				else
				{
					linje.SubItems.Add("Enkeltlinjet tekstboks");
				}
				lstAttributter.Items.Add(linje);
			}
		}

		private void btnTilføjAttribut_Click(object sender, EventArgs e)
		{
			FrmTilføjAttribut form = new FrmTilføjAttribut(kampagneManager, lstAttributter.Items.Count);
			form.ShowDialog();
			opdaterListe();
		}

		private void btnRetAttribut_Click(object sender, EventArgs e)
		{
			if (lstAttributter.SelectedIndices.Count > 0)
			{
				FrmRetAttribut form = new FrmRetAttribut(kampagneManager, long.Parse(lstAttributter.SelectedItems[0].Text), lstAttributter.SelectedIndices[0]);
				form.ShowDialog();
				opdaterListe();
			}
			else
			{
				MessageBox.Show("Vælg en attribut", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
		}

		private void btnSletAttribut_Click(object sender, EventArgs e)
		{
			if (lstAttributter.SelectedIndices.Count > 0)
			{
				if (MessageBox.Show("Vil du slette denne attribut?", "Sletning", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (!kampagneManager.SletAttribut(long.Parse(lstAttributter.SelectedItems[0].Text)))
					{
						MessageBox.Show("Der skete en fejl, da attributten skulle slettes i databasen.", "Database fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					opdaterListe();
				}
			}
			else
			{
				MessageBox.Show("Vælg en attribut", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
		}

		private void btnTilbage_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
