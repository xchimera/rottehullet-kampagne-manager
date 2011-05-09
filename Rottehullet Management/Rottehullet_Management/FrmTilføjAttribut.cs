using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using Enum;

namespace Rottehullet_Management
{
	public partial class FrmTilføjAttribut : Form
	{
		KampagneManager kampagneManager;
		int position;

		public FrmTilføjAttribut(KampagneManager kampagneManager, int position)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();
			cboType.SelectedIndex = 0;
			txtValgmulighed.Enabled = false;
			btnTilføjValgmulighed.Enabled = false;
			btnSletValgmulighed.Enabled = false;
			lstValgmuligheder.Enabled = false;
		}

		private void cboType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboType.SelectedIndex == 2)
			{
				lstValgmuligheder.Enabled = true;
				txtValgmulighed.Enabled = true;
				btnTilføjValgmulighed.Enabled = true;
				btnSletValgmulighed.Enabled = true;
			}
			else
			{
				lstValgmuligheder.Enabled = false;
				txtValgmulighed.Enabled = false;
				btnTilføjValgmulighed.Enabled = false;
				btnSletValgmulighed.Enabled = false;
			}
		}

		private void btnTilføj_Click(object sender, EventArgs e)
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
			KampagneAttributType type = (KampagneAttributType)cboType.SelectedIndex;
			if (cboType.SelectedIndex != 2)
			{
				kampagneManager.TilføjSingleAttribut(txtNavn.Text, type, position);
			}
			else
			{
				List<string> valgmuligheder = new List<string>();
				foreach (ListViewItem item in lstValgmuligheder.Items)
				{
					valgmuligheder.Add(item.Text);
				}
				kampagneManager.TilføjMultiAttribut(txtNavn.Text, type, position, valgmuligheder);
			}
			this.Close();
		}

		private void btnTilføjValgmulighed_Click(object sender, EventArgs e)
		{
			if (txtValgmulighed.Text == "")
			{
				MessageBox.Show("Elementet skal have et navn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ListViewItem item = new ListViewItem();
			item.Text = txtValgmulighed.Text;
			lstValgmuligheder.Items.Add(item);
		}

		private void btnSletValgmulighed_Click(object sender, EventArgs e)
		{
			if (lstValgmuligheder.SelectedItems.Count == 1)
			{
				if (MessageBox.Show("Vil du slette dette element?", "Sletning", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					lstValgmuligheder.Items.RemoveAt(lstValgmuligheder.SelectedIndices[0]);
				}
			}
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
