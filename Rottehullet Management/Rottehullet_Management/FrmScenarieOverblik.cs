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
	public partial class FrmScenarieOverblik : Form
	{
		//Klasse lavet af René
		private KampagneManager kampagneManager;

		public FrmScenarieOverblik(KampagneManager kampagneManager)
		{
			InitializeComponent();
			this.kampagneManager = kampagneManager;
		}

		private void FrmScenarieOverblik_Load(object sender, EventArgs e)
		{
			List<ITilmelding> tilmeldinger = kampagneManager.HentScenarieTilmeldinger();
			this.ITilmeldingBindingSource.DataSource = tilmeldinger;
			this.IScenarieBindingSource.DataSource = kampagneManager.HentNuværendeScenarie();
			this.kampagneManagerBindingSource.DataSource = kampagneManager;
			this.reportViewer1.RefreshReport();
		}
	}
}
