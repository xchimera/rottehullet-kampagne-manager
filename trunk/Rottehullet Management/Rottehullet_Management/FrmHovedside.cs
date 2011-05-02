using System;
using System.Collections;
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
			Kampagne = kampagnemanager.Kampagne;
            this.kampagneID = Kampagne.KampagneID;
            txtNavn.Text = Kampagne.Navn;
			txtHjemmeside.Text = Kampagne.Hjemmeside;
			txtBeskrivelse.Text = Kampagne.Beskrivelse;
			txtNavn.Select(0, 0);
            if (kampagnemanager.NuværendeRettighed == Enum.BrugerRettighed.Topbruger)
            {
                btnVælgSuperbruger.Visible = true;
            }
			kampagnemanager.SætNuværendeRettighed();
			if (Kampagne.Status != Enum.KampagneStatus.Åben)
			{
				btnÅbenKampagne.Text = "Åben Kampagne";
			}
			else
			{
				btnÅbenKampagne.Text = "Luk Kampagne";
			}
			if (kampagnemanager.GetAntalKampagner() > 1)
			{
				btnSkiftKampagne.Enabled = true;
			}
			else
			{
				btnSkiftKampagne.Enabled = false;
				btnSkiftKampagne.Visible = false;
			}
        }

		private void OpdaterLstKarakterer()
		{
			IKarakter karakter;
			IEnumerator karakteriterator = kampagnemanager.AlleKaraktererEnumerator();
			karakteriterator.Reset();
			lstKarakterer.Items.Clear();


			while (karakteriterator.MoveNext())
			{
				karakter = (IKarakter)karakteriterator.Current;
				ListViewItem item = new ListViewItem();
				
				item.Text = Convert.ToString(karakter.navn);
				//item.SubItems.Add(Convert.ToString(kampagne[1]));

				lstKarakterer.Items.Add(item);
			}
			//lstKarakterer.Items[0].Selected = true;
		}

        private void btnRedigerNavn_Click(object sender, EventArgs e)
        {
			InputBoxSingleline singleline = new InputBoxSingleline(Kampagne.Navn);
			singleline.ShowDialog();
            if (singleline.Lastbutton == 1)
            {
                if (singleline.Text != "")
                {
                    txtNavn.Text = singleline.Text;
                    kampagnemanager.RetKampagneNavn(txtNavn.Text, kampagneID);
                    kampagnemanager.RetKampagneliste(kampagneID, txtNavn.Text);
                }
            }
        }

        private void btnRedigerHjemmeside_Click(object sender, EventArgs e)
        {
            InputBoxSingleline singleline = new InputBoxSingleline(Kampagne.Hjemmeside);
            singleline.ShowDialog();
            if (singleline.Lastbutton == 1)
            {
                txtHjemmeside.Text = singleline.Text;
                kampagnemanager.RetKampagneHjemmeside(txtHjemmeside.Text, Kampagne.KampagneID);
            }
        }

        private void btnRedigerBeskrivelse_Click(object sender, EventArgs e)
        {
            InputBoxMultiline multiline = new InputBoxMultiline(Kampagne.Beskrivelse);
            multiline.ShowDialog();
            if (multiline.LastButton == 1)
            {
                txtBeskrivelse.Text = multiline.Text;
                kampagnemanager.RetKampagneBeskrivelse(txtBeskrivelse.Text, Kampagne.KampagneID);
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

		private void btnOpstartScenarie_Click(object sender, EventArgs e)
		{
			FrmOpstartScenarie form = new FrmOpstartScenarie(kampagnemanager);
			form.ShowDialog();
		}

        private void btnÅbenKampagne_Click(object sender, EventArgs e)
        {
			if (Kampagne.Status != Enum.KampagneStatus.Åben)
			{
				//Denne del køres når knappen hedder Åben Kampagne (når KampagneStatus er "Lukket" eller "Oprette)
				kampagnemanager.RetKampagneStatus(Kampagne.KampagneID, Enum.KampagneStatus.Åben);
				btnÅbenKampagne.Text = "Luk Kampagne";
			}
			else
			{
				//Denne del køres når knappen hedder Luk Kampagne
				kampagnemanager.RetKampagneStatus(Kampagne.KampagneID, Enum.KampagneStatus.Lukket);
				btnÅbenKampagne.Text = "Åben Kampagne";
			}
        }

		private void btnRetScenarie_Click(object sender, EventArgs e)
		{
			IScenarie scenarie = kampagnemanager.HentNuværendeScenarie();
			if (scenarie != null)
			{
				FrmRetScenarie form = new FrmRetScenarie(kampagnemanager, scenarie);
				form.ShowDialog();
			}
			else
				MessageBox.Show("Der er i øjeblikket ingen scenarie på denne kampagne", "Intet scenarie");
		}

        private void btnVælgSuperbruger_Click(object sender, EventArgs e)
        {
            FrmVælgSuperbruger vælgsuperbruger = new FrmVælgSuperbruger(kampagnemanager, Kampagne);
            this.Hide();
            vælgsuperbruger.ShowDialog();
        }
    }
}
