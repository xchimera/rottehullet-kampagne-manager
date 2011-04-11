using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rottehullet_Management
{
	public partial class FrmLoginKampagneValg : Form
	{
		Controller.KampagneManager kampagnemanager;
		List<string[]> kampagner = new List<string[]>();
        
        public FrmLoginKampagneValg(Controller.KampagneManager kampagnemanager)
		{
			InitializeComponent();
			 
			Button[] knapper = { btnKampagne1, btnKampagne2, btnKampagne3 };
			foreach (string[] kampagne in kampagnemanager.GetRettigheder())
			{
				kampagner.Add(kampagne);
			}
			this.kampagnemanager = kampagnemanager;
			
			for (int i = 0; i < kampagner.Count; i++)
			{
				knapper[i].Text = kampagner[i][1];
				if (i>2)
				{
					knapper[i].Enabled = true;
				}
			}
		}

		private void btnKampagne1_Click(object sender, EventArgs e)
		{
			startKampagne(0);
		}

		private void btnKampagne2_Click(object sender, EventArgs e)
		{
			startKampagne(1);
		}

		private void btnKampagne3_Click(object sender, EventArgs e)
		{
			startKampagne(2);
		}

		private void startKampagne(int i)
		{
			if (kampagnemanager.HentKampagneFraDatabase(Convert.ToInt64(kampagner[i][0])))
			{
				FrmHovedside hovedside = new FrmHovedside(kampagner[i][1], kampagnemanager);
				this.Hide();
				hovedside.ShowDialog();
				this.Close();
			}
			else
			{
				MessageBox.Show("Der skete en fejl under adgangen til denne kampagne.");
			}
		}
	}
}
