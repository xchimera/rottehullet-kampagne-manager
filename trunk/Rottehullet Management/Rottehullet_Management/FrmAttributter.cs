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
			opdaterList();
		}

		private void opdaterList()
		{
			IEnumerator iterator = kampagneManager.HentAttributter();
			IKampagneAttribut iKampagneAttribut;
			ListViewItem linje;

			while (iterator.MoveNext())
			{
				iKampagneAttribut = (IKampagneAttribut)iterator.Current;
				linje = new ListViewItem();
				linje.Text = iKampagneAttribut.KampagneAttributID.ToString();
				linje.SubItems.Add(iKampagneAttribut.Navn);
				if (iKampagneAttribut.Type == KampagneType.Combo)
				{
					linje.SubItems.Add("Multiple Choice");
				}
				else if (iKampagneAttribut.Type == KampagneType.Multiline)
				{
					linje.SubItems.Add("Flerlinjet tekstboks");
				}
				else
				{
					linje.SubItems.Add("Enkeltlinjet tekstboks");
				}
			}
		}

		private void btnTilføjAttrbut_Click(object sender, EventArgs e)
		{
			FrmTilføjAttribut form = new FrmTilføjAttribut(kampagneManager, lstAttributter.Items.Count);
			form.ShowDialog();
			opdaterList();
		}
	}
}
