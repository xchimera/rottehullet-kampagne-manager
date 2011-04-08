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
    public partial class FrmHovedside : Form
    {
        KampagneManager kampagnemanager;
        
        public FrmHovedside(long kampagneID, string navn, KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;

			kampagnemanager.HentKampagneFraDatabase(kampagneID);
        }
    }
}
