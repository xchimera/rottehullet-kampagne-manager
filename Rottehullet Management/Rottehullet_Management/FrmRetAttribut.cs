﻿using System;
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
		//Lavet af René
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

		//Lavet af René
		private void opdaterListe()
		{
			IEnumerator iterator = kampagneManager.HentValgmuligheder();
			IKampagneMultiAttributValgmulighed valgmulighed;
			ListViewItem linje;

			while (iterator.MoveNext())
			{
				valgmulighed = (IKampagneMultiAttributValgmulighed)iterator.Current;
				linje = new ListViewItem();
				linje.Text = valgmulighed.Id.ToString(); ;
				linje.SubItems.Add(valgmulighed.Værdi);
				lstValgmuligheder.Items.Add(linje);
			}
		}

		//Lavet af René
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

		//Lavet af René
		private void btnSletValgmulighed_Click(object sender, EventArgs e)
		{
			if (lstValgmuligheder.SelectedIndices.Count == 1)
			{
				if (MessageBox.Show("Vil du slette dette element?", "Sletning", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					ListViewItem linje = lstValgmuligheder.Items[lstValgmuligheder.SelectedIndices[0]];
					if (!kampagneManager.SletMultiAttributValgmulighed(long.Parse(linje.Text)))
					{
						MessageBox.Show("Der skete en fejl, da elementet skulle slettes i databasen.", "Database fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					lstValgmuligheder.Items.Remove(linje);
				}
			}
			else
			{
				MessageBox.Show("Vælg attributten som skal slettes", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		//Lavet af René
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

		//Lavet af René
		private void btnRet_Click(object sender, EventArgs e)
		{
			if (txtNavn.Text == "")
			{
				MessageBox.Show("Attributten skal have et navn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if (kampagneManager.FindKampagneAttribut(txtNavn.Text) != null)
			{
				MessageBox.Show("Der er allerede en attribut af dette navn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
