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
			Button[] knapper = {btnKampagne1,btnKampagne2,btnKampagne3};
			this.kampagner = kampagner;

			InitializeComponent();
			this.kampagnemanager = kampagnemanager;
			this.kampagner = kampagner;
			for (int i = 0; i < kampagner.Count; i++)
			{
				knapper[i].Text = kampagner[i][1];
			}
		}

		private void btnKampagne1_Click(object sender, EventArgs e)
		{

		}
	}
}
