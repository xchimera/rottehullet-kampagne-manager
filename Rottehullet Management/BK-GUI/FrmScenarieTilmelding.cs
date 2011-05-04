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
    public partial class FrmScenarieTilmelding : Form
    {
        public FrmScenarieTilmelding()
        {
            InitializeComponent();
        }
        //TODO:
        private void btnAnnuller_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTilmeld_Click(object sender, EventArgs e)
        {

        }
    }
}
