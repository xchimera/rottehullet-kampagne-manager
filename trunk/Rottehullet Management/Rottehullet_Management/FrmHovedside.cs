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
    public partial class FrmHovedside : Form
    {
        KampagneManager kampagnemanager;
		IKampagne Kampagne;
        
        public FrmHovedside(long kampagneID, string navn, KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;

			kampagnemanager.HentKampagneFraDatabase(kampagneID);
			Kampagne = kampagnemanager.FindKampagne(navn);

			txtNavn.Text = Kampagne.Navn;
			txtHjemmeside.Text = Kampagne.Hjemmeside;
			txtBeskrivelse.Text = Kampagne.Beskrivelse;
        }
    }
}
