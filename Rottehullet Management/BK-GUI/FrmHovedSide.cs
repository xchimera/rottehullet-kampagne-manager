using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BK_Controller;

namespace BK_GUI
{
    public partial class FrmHovedSide : Form
    {
        BrugerKlient brugerklient;
        private long kampagneID;
        public FrmHovedSide(BrugerKlient brugerklient, long kampagneID)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            this.kampagneID = kampagneID;
        }

        private void btnSkiftKampagne_Click(object sender, EventArgs e)
        {
            FrmLoginKampagneValg loginkampagnevalg = new FrmLoginKampagneValg(brugerklient);
            this.Hide();
            loginkampagnevalg.ShowDialog();
            this.Close();
        }

        private void btnTilmeldTilScenarie_Click(object sender, EventArgs e)
        {
            FrmScenarieTilmelding scenarietilmelding = new FrmScenarieTilmelding();
            this.Hide();
            scenarietilmelding.ShowDialog();
            this.Show();
        }
    }
}
