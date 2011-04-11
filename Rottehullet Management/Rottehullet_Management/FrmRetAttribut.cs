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

namespace Rottehullet_Management
{
	public partial class FrmRetAttribut : Form
	{
		KampagneManager kampagneManager;

		public FrmRetAttribut(KampagneManager kampagneManager, int id)
		{
			this.kampagneManager = kampagneManager;
			InitializeComponent();

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
		}

		private void btnTilføjValgmulighed_Click(object sender, EventArgs e)
		{

		}
	}
}
