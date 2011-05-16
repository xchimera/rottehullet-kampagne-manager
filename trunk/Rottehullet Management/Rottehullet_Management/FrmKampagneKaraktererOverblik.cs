using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using Interfaces;

namespace Rottehullet_Management
{
	public partial class FrmKampagneKaraktererOverblik : Form
	{
		KampagneManager kampagneManager;
		public FrmKampagneKaraktererOverblik(KampagneManager kampagneManager)
		{
			InitializeComponent();
			this.kampagneManager = kampagneManager;
		}

		private void FrmKampagneKaraktererOverblik_Load(object sender, EventArgs e)
		{
			this.IKarakterBindingSource.DataSource = kampagneManager.HentKaraktererTilKampagne();
			this.reportViewer1.RefreshReport();
		}
	}
}
