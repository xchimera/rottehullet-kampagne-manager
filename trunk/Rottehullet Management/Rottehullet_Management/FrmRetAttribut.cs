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
				linje.Text = valgmulighed[0];
				linje.SubItems.Add(valgmulighed[1]);
				lstValgmuligheder.Items.Add(linje);
			}
		}

		private void btnTilføjValgmulighed_Click(object sender, EventArgs e)
		{
			ListViewItem item = new ListViewItem();
			item.Text = "";
			item.SubItems.Add(txtValgmulighed.Text);
			lstValgmuligheder.Items.Add(item);
		}

		private void btnSletValgmulighed_Click(object sender, EventArgs e)
		{
			ListViewItem linje = lstValgmuligheder.Items[lstValgmuligheder.SelectedIndices[0]];
			if (linje.Text != "")
			{
				//TODO:
				//Slet valgmulighed
			}
			lstValgmuligheder.Items.Remove(linje);
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
		}

		private void btnRet_Click(object sender, EventArgs e)
		{
			kampagneManager.RetAttribut(txtNavn.Text, (KampagneType)cboType.SelectedIndex, position);
			this.Close();
		}
	}
}
