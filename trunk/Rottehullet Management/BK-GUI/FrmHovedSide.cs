using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BK_Controller;
using Interfaces;
using Enum;

namespace BK_GUI
{
    public partial class FrmHovedSide : Form
    {
        BrugerKlient brugerklient;
        IKampagne ikampagne;
        List<Control> kontroller;
        List<List<long>> listvalgID;
		TilstandBruger tilstand;
		long nuværendeKarakterID;


        public FrmHovedSide(BrugerKlient brugerklient, long kampagneID)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            kontroller = new List<Control>();
            listvalgID = new List<List<long>>();
            ikampagne = brugerklient.FindKampagne(kampagneID);
			//Loaded Karakter
			TilstandIngenLoadedKarakter();            
        }

		#region TilstandsStyring
		private void TilstandIngenLoadedKarakter()
		{
			tilstand = TilstandBruger.IngenLoadedKarakter;
			btnNyOpdaterDisabled.Text = "Ny Karakter";
			btnNyOpdaterDisabled.Enabled = true;
			btnTilmeldTilScenarie.Enabled = false;

			FjernKontroler();
			OpdaterListView();
		}

		private void TilstandLavNyKarakter()
		{
			tilstand = TilstandBruger.LavNyKarakter;
			btnNyOpdaterDisabled.Text = "Indsend Karakter";
			btnNyOpdaterDisabled.Enabled = true;
			btnTilmeldTilScenarie.Enabled = false;
		}

		private void TilstandNyesteKarakter()
		{
			tilstand = TilstandBruger.NyesteKarakter;
			btnNyOpdaterDisabled.Text = "Opdater Karakter";
			btnNyOpdaterDisabled.Enabled = true;
			btnTilmeldTilScenarie.Enabled = true;
		}

		#endregion


		//Denne knap bruges både til at lave nye karakterer, indsende dem og opdatere dem
		void btnNyOpdaterDisabled_Click(object sender, EventArgs e)
		{
			//Lav ny karakter
			if (tilstand == TilstandBruger.IngenLoadedKarakter)
			{
				OpretAttributter();
				TilstandLavNyKarakter();
			}
			//Indsend Karakter
			else if (tilstand == TilstandBruger.LavNyKarakter)
			{
				if (brugerklient.NyKarakter(kontroller.GetEnumerator(), listvalgID.GetEnumerator(), KarakterStatus.Nyoprettet))
				{
					MessageBox.Show("Karakteren er blevet indsendt");
					TilstandIngenLoadedKarakter();
				}
				else
				{
					MessageBox.Show("Der skete en fejl under indsendelsen af karakteren", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			//Opdater Karakter
			else if (tilstand == TilstandBruger.NyesteKarakter)
			{
				if (brugerklient.OpdaterKarakter(kontroller.GetEnumerator(), listvalgID.GetEnumerator(), nuværendeKarakterID, KarakterStatus.Opdateret))
				{
					MessageBox.Show("Den opdaterede karakter er blevet indsendt");
					TilstandIngenLoadedKarakter();
				}
				else
				{
					MessageBox.Show("Der skete en fejl under indsendelsen af den opdaterede karakter", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
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
			if (lstkaraktere.SelectedIndices.Count == 1)
			{
				IScenarie scenarie = brugerklient.HentNuværendeScenarie();

				if (scenarie == null)
				{
					MessageBox.Show("Der findes endnu ikke et scenarie på denne kampagne", "Der findes ikke et scenarie");
					return;
				}

				FrmScenarieTilmelding scenarietilmelding = new FrmScenarieTilmelding(brugerklient, nuværendeKarakterID, scenarie);
				this.Hide();
				scenarietilmelding.ShowDialog();
				this.Show();
			}
			else
			{
				MessageBox.Show("Du skal vælge en karakter, før du trykker på denne knap", "Ingen karakter valgt");
			}
        }

		private void lstkaraktere_MouseClick(object sender, MouseEventArgs e)
		{
			ListViewItem item = lstkaraktere.Items[lstkaraktere.SelectedIndices[0]];
			nuværendeKarakterID = Convert.ToInt64(item.SubItems[0].Text);
			TilstandNyesteKarakter();
			FjernKontroler();
			SetAttributter();
			
		}

		public void FjernKontroler()
		{
			foreach (Control control in kontroller)
			{
				this.Controls.Remove(control);
			}
			kontroller.Clear();
			listvalgID.Clear();
			this.Update();
		}

		#region ListeMetoder
		public void OpdaterListView()
		{
			IKarakter ikarakter;
			IEnumerator karakteriterator = brugerklient.GetKarakterIterator();

			karakteriterator.Reset();
			lstkaraktere.Items.Clear();


			while (karakteriterator.MoveNext())
			{
				ikarakter = (IKarakter)karakteriterator.Current;
				if (ikarakter.Status != KarakterStatus.Gammel)
				{
					ListViewItem item = new ListViewItem();

					if (ikarakter.Kampagne.KampagneID == ikampagne.KampagneID)
					{
						item.Text = ikarakter.KarakterID.ToString();
						item.SubItems.Add(ikarakter["Navn"]);
						lstkaraktere.Items.Add(item);
					}
				}
			}
		}

		public void OpretAttributter()
		{
			IKampagneAttribut ikampagneattribut;
			IKampagneMultiAttributValgmulighed valgmulighed;
			IEnumerator attributiterator = brugerklient.GetAttributIterator(ikampagne.KampagneID);
			int y = 5;
			int x = 5;
			Panel opretattributpanel = new Panel();
			opretattributpanel.AutoScroll = true;
			opretattributpanel.Size = new Size(290, 400);
			opretattributpanel.Location = new Point(x + lstkaraktere.Width + 5 + lstkaraktere.Location.X, lstkaraktere.Location.Y);
			opretattributpanel.BorderStyle = BorderStyle.Fixed3D;
			this.Controls.Add(opretattributpanel);
			kontroller.Add(opretattributpanel);

			attributiterator.Reset();
			while (attributiterator.MoveNext())
			{
				ikampagneattribut = (IKampagneAttribut)attributiterator.Current;
				if (ikampagneattribut.Type == Enum.KampagneAttributType.Singleline)
				{
					// -- label --
					Label label = new Label();
					label.Text = ikampagneattribut.Navn;
					label.RightToLeft = RightToLeft.No;
					label.Location = new Point(x, y);

					// -- textbox --
					TextBox textbox = new TextBox();
					textbox.RightToLeft = RightToLeft.No;
					textbox.Location = new Point(x + label.Width + 10, y);
					textbox.Name = ikampagneattribut.KampagneAttributID.ToString();


					// -- controladd --
					this.Controls.Add(textbox);
					this.Controls.Add(label);
					y += textbox.Height + 5;
					kontroller.Add(textbox);
					kontroller.Add(label);
					opretattributpanel.Controls.Add(textbox);
					opretattributpanel.Controls.Add(label);

				}
				else if (ikampagneattribut.Type == Enum.KampagneAttributType.Multiline)
				{
					// -- label --
					Label label = new Label();
					label.Text = ikampagneattribut.Navn;
					label.RightToLeft = RightToLeft.No;
					label.Location = new Point(x, y);

					// -- textbox --
					TextBox textbox = new TextBox();
					textbox.Location = new Point(x + label.Width + 10, y);
					textbox.Multiline = true;
					textbox.Name = ikampagneattribut.KampagneAttributID.ToString();
					textbox.Size = new System.Drawing.Size(150, 100);

					//                
					y += textbox.Height + 5;
					this.Controls.Add(textbox);
					this.Controls.Add(label);
					kontroller.Add(textbox);
					kontroller.Add(label);
					opretattributpanel.Controls.Add(textbox);
					opretattributpanel.Controls.Add(label);

				}
				else if (ikampagneattribut.Type == Enum.KampagneAttributType.Combo)
				{
					List<long> valgIDer = new List<long>();
					IEnumerator valgmulighediterator =
						brugerklient.GetValgmulighederIterator(ikampagneattribut.KampagneAttributID,
															   ikampagne.KampagneID);
					// -- label --
					Label label = new Label();
					label.Text = ikampagneattribut.Navn;
					label.Location = new Point(x, y);
					label.RightToLeft = System.Windows.Forms.RightToLeft.No;

					// -- ComboBox --
					ComboBox combobox = new ComboBox();
					combobox.Location = new Point(x + label.Width + 10, y);
					while (valgmulighediterator.MoveNext())
					{
						valgmulighed = (IKampagneMultiAttributValgmulighed)valgmulighediterator.Current;
						combobox.Items.Add(valgmulighed.Værdi);
						valgIDer.Add(valgmulighed.Id);
					}
					combobox.Name = ikampagneattribut.KampagneAttributID.ToString();

					// -- kontroladd --
					y += combobox.Height + 5;
					this.Controls.Add(combobox);
					this.Controls.Add(label);
					kontroller.Add(combobox);
					kontroller.Add(label);
					listvalgID.Add(valgIDer);
					opretattributpanel.Controls.Add(combobox);
					opretattributpanel.Controls.Add(label);
				}
			}
		}

	    private void SetAttributter()
        {
            IEnumerator attributiterator = brugerklient.GetAttributIterator(ikampagne.KampagneID);
            ListViewItem item = lstkaraktere.Items[lstkaraktere.SelectedIndices[0]];
            IKarakter ikarakter = brugerklient.GetKarakter(Convert.ToInt64(item.SubItems[0].Text));
            IKampagneAttribut ikampagneattribut ;
            IKampagneMultiAttributValgmulighed valgmulighed;


            int y = 5;
            int x = 5;
            IEnumerator karakterattribut = brugerklient.GetVærdiIterator(ikarakter.KarakterID);
            IEnumerator værdi = ikarakter.HentVærdier();
            Panel setattributpanel = new Panel();
            setattributpanel.AutoScroll = true;
            setattributpanel.Size = new Size(290, 400);
            setattributpanel.Location = new Point(x + lstkaraktere.Width + 5 + lstkaraktere.Location.X, lstkaraktere.Location.Y);
            setattributpanel.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(setattributpanel);
            kontroller.Add(setattributpanel);

			Label lblkarakterstatus = new Label();
			lblkarakterstatus.RightToLeft = RightToLeft.No;
			lblkarakterstatus.Location = new Point(x, y);
			lblkarakterstatus.Text = "Status: " + ikarakter.Status.ToString();
			this.Controls.Add(lblkarakterstatus);
			setattributpanel.Controls.Add(lblkarakterstatus);
			y += lblkarakterstatus.Height + 5;
                           
			værdi.Reset();
            karakterattribut.Reset();
            attributiterator.Reset();
            while (karakterattribut.MoveNext() && værdi.MoveNext() && attributiterator.MoveNext())
            {
                ikampagneattribut = (IKampagneAttribut)attributiterator.Current;
                IKarakterAttribut ikarakterattribut = (IKarakterAttribut)karakterattribut.Current;
                if (ikarakterattribut.Kampagneattribut.Type == KampagneAttributType.Singleline)
                {
                    // -- label --
                    Label label = new Label();
                    label.RightToLeft = RightToLeft.No;
                    label.Location = new Point(x, y);
                    label.Text = ikampagneattribut.Navn;

                    // -- textbox --
                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(x + label.Width + 10, y);
                    textbox.Text = værdi.Current.ToString();
                    textbox.Name = ikampagneattribut.KampagneAttributID.ToString();

                    // -- controladd --))
                    this.Controls.Add(textbox);
                    this.Controls.Add(label);
                    y += textbox.Height + 5;
                    kontroller.Add(textbox);
                    kontroller.Add(label);
                    setattributpanel.Controls.Add(textbox);
                    setattributpanel.Controls.Add(label);

                }
                if (ikarakterattribut.Kampagneattribut.Type == KampagneAttributType.Multiline)
                {
                    // -- label --
                    Label label = new Label();
                    label.RightToLeft = RightToLeft.No;
                    label.Text = ikampagneattribut.Navn;
                    label.Location = new Point(x, y);

                    // -- textbox --
                    TextBox textbox = new TextBox();
                    textbox.Multiline = true;
                    textbox.Location = new Point(x + label.Width + 10, y);
                    textbox.Name = ikampagneattribut.KampagneAttributID.ToString();
                    textbox.Text = værdi.Current.ToString();
                    textbox.Size = new System.Drawing.Size(150, 100);

                    // -- controladd --
                    this.Controls.Add(textbox);
                    this.Controls.Add(label);
                    y += textbox.Height + 5;
                    kontroller.Add(textbox);
                    kontroller.Add(label);
                    setattributpanel.Controls.Add(textbox);
                    setattributpanel.Controls.Add(label);

                }
                if (ikarakterattribut.Kampagneattribut.Type == KampagneAttributType.Combo)
                {
                    List<long> valgIDer = new List<long>();
                    // -- label --
                    Label label = new Label();
                    label.Text = ikampagneattribut.Navn;
                    label.Location = new Point(x, y);
                    label.RightToLeft = System.Windows.Forms.RightToLeft.No;

                    // -- ComboBox --
                    IEnumerator valgmuligheder =
                        brugerklient.GetValgmulighederIterator(ikarakterattribut.Kampagneattribut.KampagneAttributID,
                                                               ikampagne.KampagneID);
                    ComboBox combobox = new ComboBox();
                    combobox.Location = new Point(x + label.Width + 10, y);
                    combobox.Name = ikampagneattribut.KampagneAttributID.ToString();
                    while (valgmuligheder.MoveNext())
                    {
                        valgmulighed = (IKampagneMultiAttributValgmulighed)valgmuligheder.Current;
                        combobox.Items.Add(valgmulighed.Værdi);
                        combobox.SelectedItem = værdi.Current;
                        valgIDer.Add(valgmulighed.Id);
                    }

                    // -- kontroladd --
                    y += combobox.Height + 5;
                    this.Controls.Add(combobox);
                    this.Controls.Add(label);
                    kontroller.Add(combobox);
                    kontroller.Add(label);
                    listvalgID.Add(valgIDer);
                    setattributpanel.Controls.Add(combobox);
                    setattributpanel.Controls.Add(label);
                }
            }
        }

		#endregion

		
    }
}
