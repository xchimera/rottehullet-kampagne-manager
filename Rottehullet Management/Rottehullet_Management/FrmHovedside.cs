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
		IKampagne kampagne;
        long kampagneID;
        
        public FrmHovedside(string navn, KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
			kampagne = kampagnemanager.Kampagne;
            this.kampagneID = kampagne.KampagneID;
            txtNavn.Text = kampagne.Navn;
			txtHjemmeside.Text = kampagne.Hjemmeside;
			txtBeskrivelse.Text = kampagne.Beskrivelse;
			txtNavn.Select(0, 0);
			//Sætter brugerens rettighedsniveau på Kampagnemanager, og viser knapper som kun er relevante for Superbrugeren
			if (kampagnemanager.SætNuværendeRettighed() == Enum.BrugerRettighed.Topbruger)
			{
				Tilstand_Topbruger();
			}
			//Dette sætter tilstande afhængig om kampagnen er nyoprettet, åben eller lukket
			SætKampagneTilstand();
			//Hvis brugeren kun har 1 kampagne skal Skift Kampagne knappen ikke vises
			if (kampagnemanager.GetAntalKampagner() == 1)
			{
				btnSkiftKampagne.Enabled = false;
				btnSkiftKampagne.Visible = false;
			}
			OpdaterLstKarakterer();
        }

		#region Tilstandsstyring
		private void Tilstand_Topbruger()
		{
			btnVælgSuperbruger.Visible = true;
		}
		
		private void SætKampagneTilstand()
		{
			if (kampagne.Status == Enum.KampagneStatus.Oprettet)
			{
				Tilstand_Nyoprettet();
			}
			else if (kampagne.Status == Enum.KampagneStatus.Åben)
			{
				Tilstand_Åben();
			}
			else //Status = Lukket
			{
				Tilstand_Lukket();
			}
		}

		private void Tilstand_Nyoprettet()
		{
			btnÅbenKampagne.Text = "Åben Kampagne";
			btnRetAttributter.Enabled = true;
			btnRetAttributter.Visible = true;
		}

		private void Tilstand_Åben()
		{
			btnÅbenKampagne.Text = "Luk Kampagne";
			btnRetAttributter.Enabled = false;
			btnRetAttributter.Visible = false;
		}

		private void Tilstand_Lukket()
		{
			btnÅbenKampagne.Text = "Åben Kampagne";
			btnRetAttributter.Enabled = false;
			btnRetAttributter.Visible = false;
		}
		#endregion

		private void OpdaterLstKarakterer()
		{
			IKarakter karakter;
			IEnumerator karakteriterator = kampagnemanager.AlleKaraktererEnumerator();
			karakteriterator.Reset();
			lstKarakterer.Items.Clear();


			while (karakteriterator.MoveNext())
			{
				karakter = (IKarakter)karakteriterator.Current;
				if (karakter.Status != Enum.KarakterStatus.Gammel && karakter.Status != Enum.KarakterStatus.Afslået)
				{
					ListViewItem item = new ListViewItem();

					item.Text = Convert.ToString(karakter.KarakterID);
					item.SubItems.Add(karakter["Navn"]);
					if (karakter.Status == Enum.KarakterStatus.Nyoprettet)
					{
						item.BackColor = Color.LightSalmon;
					}
					else if (karakter.Status == Enum.KarakterStatus.Opdateret)
					{
						item.BackColor = Color.LightBlue;
					}

					lstKarakterer.Items.Add(item);
				}
			}
		}

        private void btnRedigerNavn_Click(object sender, EventArgs e)
        {
			InputBoxSingleline singleline = new InputBoxSingleline(kampagne.Navn);
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
            InputBoxSingleline singleline = new InputBoxSingleline(kampagne.Hjemmeside);
            singleline.ShowDialog();
            if (singleline.Lastbutton == 1)
            {
                txtHjemmeside.Text = singleline.Text;
                kampagnemanager.RetKampagneHjemmeside(txtHjemmeside.Text, kampagne.KampagneID);
            }
        }

        private void btnRedigerBeskrivelse_Click(object sender, EventArgs e)
        {
            InputBoxMultiline multiline = new InputBoxMultiline(kampagne.Beskrivelse);
            multiline.ShowDialog();
            if (multiline.LastButton == 1)
            {
                txtBeskrivelse.Text = multiline.Text;
                kampagnemanager.RetKampagneBeskrivelse(txtBeskrivelse.Text, kampagne.KampagneID);
            }
        }

		private void btnSkiftKampagne_Click(object sender, EventArgs e)
		{
			FrmLoginKampagneValg loginKampagneValg = new FrmLoginKampagneValg(kampagnemanager);
			this.Hide(); 
			kampagnemanager.TømKarakterer();
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
			if (kampagne.Status != Enum.KampagneStatus.Åben)
			{
				//Denne del køres når KampagneStatus er "Lukket" eller "Oprettet", og retter status
				//til "Åben"
				kampagnemanager.RetKampagneStatus(kampagne.KampagneID, Enum.KampagneStatus.Åben);
			}
			else
			{
				//Denne del køres når KampagneStatus er "Åben", og retter status til "Lukket"
				kampagnemanager.RetKampagneStatus(kampagne.KampagneID, Enum.KampagneStatus.Lukket);
			}
			SætKampagneTilstand();
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
            FrmVælgSuperbruger vælgsuperbruger = new FrmVælgSuperbruger(kampagnemanager, kampagne);
            this.Hide();
            vælgsuperbruger.ShowDialog();
        }

		private void lstKarakterer_DoubleClick(object sender, EventArgs e)
		{
			ListViewItem valgteitem = lstKarakterer.Items[lstKarakterer.SelectedIndices[0]];
			long karakterID = Convert.ToInt64(valgteitem.SubItems[0].Text);
			IKarakter ikarakter = kampagnemanager.FindKarakter(karakterID);
			IBruger ibruger = kampagnemanager.FindKaraktersBruger(karakterID);
			FrmKarakter karaktervindue = new FrmKarakter(kampagnemanager,ibruger,ikarakter,this);
			karaktervindue.ShowDialog();
		}
    }
}
