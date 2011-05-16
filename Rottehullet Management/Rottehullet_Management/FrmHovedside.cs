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
        
		//Lavet af Thorbjørn
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
			OpdaterLstTilmeldte();
            kampagnemanager.HentSuperbruger();
        }

		#region Tilstandsstyring
		//Lavet af Thorbjørn
		private void Tilstand_Topbruger()
		{
			btnVælgSuperbruger.Visible = true;
		}

		//Lavet af Thorbjørn
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

		//Lavet af Thorbjørn
		private void Tilstand_Nyoprettet()
		{
			btnÅbenKampagne.Text = "Åben Kampagne";
			btnRetAttributter.Enabled = true;
			btnRetAttributter.Visible = true;
		}

		//Lavet af Thorbjørn
		private void Tilstand_Åben()
		{
			btnÅbenKampagne.Text = "Luk Kampagne";
			btnRetAttributter.Enabled = false;
			btnRetAttributter.Visible = false;
		}

		//Lavet af Thorbjørn
		private void Tilstand_Lukket()
		{
			btnÅbenKampagne.Text = "Åben Kampagne";
			btnRetAttributter.Enabled = false;
			btnRetAttributter.Visible = false;
		}
		#endregion

		//Lavet af Thorbjørn
		public void OpdaterLstKarakterer()
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

		//Lavet af Thorbjørn
		public void OpdaterLstTilmeldte()
		{
			IKarakter karakter;
			IEnumerator deltageriterator = kampagnemanager.HentDeltagere();
			deltageriterator.Reset();
			lstTilmeldte.Items.Clear();


			while (deltageriterator.MoveNext())
			{
				karakter = (IKarakter)deltageriterator.Current;
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

				lstTilmeldte.Items.Add(item);
			}
		}

		//Lavet af Søren
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
                    kampagnemanager.RetBrugerRettigheder(kampagneID, txtNavn.Text);
                }
            }
        }

		//Lavet af Søren
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

		//Lavet af Søren
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

		//Lavet af Thorbjørn
		private void btnSkiftKampagne_Click(object sender, EventArgs e)
		{
			FrmLoginKampagneValg loginKampagneValg = new FrmLoginKampagneValg(kampagnemanager);
			this.Hide();
			kampagnemanager.ResetKampagne();
			loginKampagneValg.ShowDialog();
			this.Close();
		}

		//Lavet af René
        private void btnRetAttributter_Click(object sender, EventArgs e)
        {
            FrmAttributter attributter = new FrmAttributter(kampagnemanager);
            attributter.ShowDialog();
            
        }

		//Lavet af René
		private void btnOpstartScenarie_Click(object sender, EventArgs e)
		{
			FrmOpstartScenarie form = new FrmOpstartScenarie(kampagnemanager);
			form.ShowDialog();
		}

		//Lavet af Thorbjørn
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

		//Lavet af René
		private void btnRetScenarie_Click(object sender, EventArgs e)
		{
			IScenarie scenarie = kampagnemanager.HentNuværendeScenarie();
			if (scenarie != null)
			{
				FrmRetScenarie form = new FrmRetScenarie(kampagnemanager, scenarie);
				form.ShowDialog();
			}
			else
				MessageBox.Show("Der er i øjeblikket ingen scenarie på denne kampagne", "Systemfejl");
		}

		//Lavet af Denny
        private void btnVælgSuperbruger_Click(object sender, EventArgs e)
        {
            FrmVælgSuperbruger vælgsuperbruger = new FrmVælgSuperbruger(kampagnemanager, kampagne);
            this.Hide();
            vælgsuperbruger.ShowDialog();
            this.Show();
        }

		//Lavet af Thorbjørn
		private void lstKarakterer_DoubleClick(object sender, EventArgs e)
		{
			ListViewItem valgteitem = lstKarakterer.Items[lstKarakterer.SelectedIndices[0]];
			long karakterID = Convert.ToInt64(valgteitem.SubItems[0].Text);
			IKarakter ikarakter = kampagnemanager.FindKarakter(karakterID);
			IBruger ibruger = kampagnemanager.FindKaraktersBruger(karakterID);
			FrmKarakter karaktervindue = new FrmKarakter(kampagnemanager,ibruger,ikarakter,this);
			karaktervindue.ShowDialog();
		}

		//Lavet af René
		private void btnPrintTilmeldte_Click(object sender, EventArgs e)
		{
			FrmScenarieOverblik form = new FrmScenarieOverblik(kampagnemanager);
			form.Show();
		}

		//Lavet af Thorbjørn
		private void lstTilmeldte_DoubleClick(object sender, EventArgs e)
		{
			ListViewItem valgteitem = lstTilmeldte.Items[lstTilmeldte.SelectedIndices[0]];
			long karakterID = Convert.ToInt64(valgteitem.SubItems[0].Text);
			IKarakter ikarakter = kampagnemanager.FindKarakter(karakterID);
			IBruger ibruger = kampagnemanager.FindKaraktersBruger(karakterID);
			FrmKarakter karaktervindue = new FrmKarakter(kampagnemanager, ibruger, ikarakter, this);
			karaktervindue.ShowDialog();
		}

		private void btnPrintKarakterer_Click(object sender, EventArgs e)
		{
			FrmKampagneKaraktererOverblik form = new FrmKampagneKaraktererOverblik(kampagnemanager);
			form.Show();
		}
    }
}
