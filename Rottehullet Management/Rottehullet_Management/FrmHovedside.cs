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
using InputBox;

namespace Rottehullet_Management
{
    public partial class FrmHovedside : Form
    {
        KampagneManager kampagnemanager;
		IKampagne Kampagne;
        long kampagneID;
        
        public FrmHovedside(string navn, KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;

			Kampagne = kampagnemanager.FindKampagne(navn);

            this.kampagneID = Kampagne.KampagneID;            
			txtNavn.Text = Kampagne.Navn;
			txtHjemmeside.Text = Kampagne.Hjemmeside;
			txtBeskrivelse.Text = Kampagne.Beskrivelse;
			if (kampagnemanager.GetAntalKampagner() > 1)
			{
				btnSkiftKampagne.Enabled = true;
			}
			else
			{
				btnSkiftKampagne.Enabled = false;
			}
        }

        private void btnRedigerNavn_Click(object sender, EventArgs e)
        {
            InputBoxSingleline singleline = new InputBoxSingleline();
            singleline.ShowDialog();
            if (singleline.Lastbutton == 1)
            {
                if (singleline.Text != "")
                {
                    txtNavn.Text = singleline.Text;
                    kampagnemanager.RetKampagneNavn(txtNavn.Text, kampagneID);
                }
            }
        }

        private void btnRedigerHjemmeside_Click(object sender, EventArgs e)
        {
            InputBoxSingleline singleline = new InputBoxSingleline();
            singleline.ShowDialog();
            if (singleline.Lastbutton == 1)
            {
                txtHjemmeside.Text = Text = singleline.Text;
                kampagnemanager.RetKampagneHjemmeside(txtHjemmeside.Text, Kampagne.KampagneID);
            }
        }

        private void btnRedigerBeskrivelse_Click(object sender, EventArgs e)
        {
            InputBoxMultiline multiline = new InputBoxMultiline();
            multiline.ShowDialog();
            if (multiline.LastButton == 1)
            {
                if (multiline.Text != "")
                {
                    txtBeskrivelse.Text = multiline.Text;
                    kampagnemanager.RetKampagneBeskrivelse(txtBeskrivelse.Text, Kampagne.KampagneID);
                }
            }
        }

		private void btnSkiftKampagne_Click(object sender, EventArgs e)
		{
			FrmLoginKampagneValg loginKampagneValg = new FrmLoginKampagneValg(kampagnemanager);
			this.Hide();
			loginKampagneValg.ShowDialog();
			this.Close();
		}

        private void btnRetAttributter_Click(object sender, EventArgs e)
        {
            FrmAttributter attributter = new FrmAttributter(kampagnemanager);
            attributter.ShowDialog();
            
        }
    }
}
