﻿using System;
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
    public partial class FrmAdminSektion : Form
    {
        KampagneManager kampagnemanager;

        public FrmAdminSektion(KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
        }

		//Lavet af Søren
        private void button1_Click(object sender, EventArgs e)
        {
            FrmOpretKampagne frmopretkampagne = new FrmOpretKampagne(kampagnemanager);
            frmopretkampagne.ShowDialog();

        }
    }
}
