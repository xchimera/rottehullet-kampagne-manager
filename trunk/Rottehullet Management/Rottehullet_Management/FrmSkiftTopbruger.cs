using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;

namespace Rottehullet_Management
{
	public partial class FrmSkiftTopbruger : Form
	{
		KampagneManager kampagneManager;

		public FrmSkiftTopbruger(KampagneManager kampagneManager)
		{
			InitializeComponent();
			this.kampagneManager = kampagneManager;
		}

		private void opdaterKampagneListe()
		{

		}
	}
}
