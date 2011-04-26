using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Enum;
using Controller;
using Interfaces;
using InputBox;

namespace Rottehullet_Management
{
	public partial class FrmRetAttribut : Form
	{
		KampagneManager kampagneManager;
		long attributId;
		int position;
		public FrmRetAttribut(KampagneManager kampagneManager, long id, int position)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();

			this.attributId = id;
			this.position = position;
			IKampagneAttribut kampagneAttribut = kampagneManager.FindKampagneAttribut(id);

			txtNavn.Text = kampagneAttribut.Navn;
			cboType.SelectedIndex = (int)kampagneAttribut.Type;
			if (cboType.SelectedIndex != 2)
			{
				txtValgmulighed.Enabled = false;
				btnTilføjValgmulighed.Enabled = false;
				btnSletValgmulighed.Enabled = false;
				lstValgmuligheder.Enabled = false;
			}
			else
			{
				txtValgmulighed.Enabled = true;
				btnTilføjValgmulighed.Enabled = true;
				btnSletValgmulighed.Enabled = true;
				lstValgmuligheder.Enabled = true;
				opdaterListe();
			}
		}

		private void opdaterListe()
		{
			IEnumerator iterator = kampagneManager.HentValgmuligheder();
			string[] valgmulighed;
			ListViewItem linje;

			while (iterator.MoveNext())
			{
				valgmulighed = (string[])iterator.Current;
				linje = new ListViewItem();
				linje.Text = valgmulighed[1];
				linje.SubItems.Add(valgmulighed[0]);
				lstValgmuligheder.Items.Add(linje);
			}
		}

		private void btnTilføjValgmulighed_Click(object sender, EventArgs e)
		{
			if (txtValgmulighed.Text == "")
			{
				MessageBox.Show("Valgmuligheden skal have et navn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			long entryID = kampagneManager.TilføjMultiAttributEntry(txtValgmulighed.Text);
			if (entryID != -1)
			{
				ListViewItem item = new ListViewItem();
				item.Text = entryID.ToString();
				item.SubItems.Add(txtValgmulighed.Text);
				lstValgmuligheder.Items.Add(item);
			}
			else
			{
				MessageBox.Show("Der skete en fejl med databasen, prøv igen senere.", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSletValgmulighed_Click(object sender, EventArgs e)
		{
			if (lstValgmuligheder.SelectedIndices.Count > 0)
			{
				ListViewItem linje = lstValgmuligheder.Items[lstValgmuligheder.SelectedIndices[0]];
				kampagneManager.SletMultiAttributValgmulighed(long.Parse(linje.Text));
				lstValgmuligheder.Items.Remove(linje);
			}
			else
			{
				MessageBox.Show("Vælg attributten som skal slettes", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnRetValgmulighed_Click(object sender, EventArgs e)
		{
			if (lstValgmuligheder.SelectedIndices.Count == 1)
			{
				InputBoxSingleline inputboks = new InputBoxSingleline(lstValgmuligheder.SelectedItems[0].SubItems[1].Text);
				inputboks.ShowDialog();

				string tekst = inputboks.Text;
				if (lstValgmuligheder.SelectedItems[0].Text != "")
				{
					if (kampagneManager.RetKampagneMultiAttributEntry(long.Parse(lstValgmuligheder.SelectedItems[0].Text), attributId, tekst))
					{
						lstValgmuligheder.SelectedItems[0].SubItems[1].Text = tekst;
					}
				}
				else
				{
					lstValgmuligheder.SelectedItems[0].Text = tekst;
				}
			}
			else
			{
				MessageBox.Show("Vælg attributten som skal rettes", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnRet_Click(object sender, EventArgs e)
		{
			if (txtNavn.Text == "")
			{
				MessageBox.Show("Attributten skal have et navn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			kampagneManager.RetAttribut(txtNavn.Text, (KampagneAttributType)cboType.SelectedIndex, position);
			this.Close();
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
