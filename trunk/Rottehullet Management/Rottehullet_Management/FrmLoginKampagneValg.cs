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
		List<string[]> kampagner;
        
        public FrmLoginKampagneValg(Controller.KampagneManager kampagnemanager, List<string[]> kampagner)
		{

			InitializeComponent();
			Button[] knapper = {btnKampagne1, btnKampagne2, btnKampagne3 };
            this.kampagner = kampagner;
			
			this.kampagnemanager = kampagnemanager;
			this.kampagner = kampagner;
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
			FrmHovedside hovedside = new FrmHovedside(Convert.ToInt64(kampagner[0][0]), kampagnemanager);
			this.Hide();
			hovedside.ShowDialog();
			this.Close();
		}

		private void btnKampagne2_Click(object sender, EventArgs e)
		{
			FrmHovedside hovedside = new FrmHovedside(Convert.ToInt64(kampagner[1][0]), kampagnemanager);
			this.Hide();
			hovedside.ShowDialog();
			this.Close();
		}

		private void btnKampagne3_Click(object sender, EventArgs e)
		{
			FrmHovedside hovedside = new FrmHovedside(Convert.ToInt64(kampagner[2][0]), kampagnemanager);
			this.Hide();
			hovedside.ShowDialog();
			this.Close();
		}
	}
}
