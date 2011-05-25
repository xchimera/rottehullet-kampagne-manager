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

namespace Rottehullet_Management
{
	public partial class FrmKarakter : Form
	{
		KampagneManager kampagnemanager;
		IBruger bruger;
		IKarakter karakter;
		FrmHovedside hvdside;
		
		//Lavet af Thorbjørn
		public FrmKarakter(KampagneManager kampagnemanager, IBruger bruger, IKarakter karakter, FrmHovedside hovedside)
		{
			InitializeComponent();
			this.kampagnemanager = kampagnemanager;
			this.bruger = bruger;
			this.karakter = karakter;
			this.hvdside = hovedside;
			txtNavn.Text = bruger.Navn;
			txtAlder.Text = bruger.Alder.ToString();
			txtEmail.Text = bruger.Email;
			txtTelefon.Text = bruger.Tlf.ToString();
			txtKontaktperson.Text = bruger.NødTlf.ToString();
			this.Text = karakter["Navn"];

			SætAttributter();
			OpdaterListview();

			if (karakter.Status == Enum.KarakterStatus.Nyoprettet)
			{
				btnGodkendKarakter.Enabled = true;
				btnGodkendKarakter.Visible = true;
				btnGodkendKarakter.Text = "Godkend Karakter";
				btnAfslåKarakter.Enabled = true;
				btnAfslåKarakter.Visible = true;
				btnAfslåKarakter.Text = "Afslå Karakter";
			}
			else if (karakter.Status == Enum.KarakterStatus.Opdateret)
			{
				btnGodkendKarakter.Enabled = true;
				btnGodkendKarakter.Visible = true;
				btnGodkendKarakter.Text = "Godkend Opgradering";
				btnAfslåKarakter.Enabled = true;
				btnAfslåKarakter.Visible = true;
				btnAfslåKarakter.Text = "Afslå Opgradering";
			}
		}

		//Lavet af Thorbjørn
		private void btnGodkendKarakter_Click(object sender, EventArgs e)
		{
			if (kampagnemanager.SætKarakterStatus(karakter, Enum.KarakterStatus.Godkendt))
			{
				btnGodkendKarakter.Enabled = false;
				btnGodkendKarakter.Visible = false;
				btnAfslåKarakter.Enabled = false;
				btnAfslåKarakter.Visible = false;
				hvdside.OpdaterLstKarakterer();
				hvdside.OpdaterLstTilmeldte();
				MessageBox.Show("Karakteren er blevet godkendt", "Godkendt", MessageBoxButtons.OK, MessageBoxIcon.None);
			}
			else
			{
				MessageBox.Show("Der skete en fejl og karakteren er ikke blevet godkendt", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//Lavet af Thorbjørn
		private void btnAfslåKarakter_Click(object sender, EventArgs e)
		{
			IKarakter forrigekarakter = kampagnemanager.FindKarakter(Convert.ToInt64(lstGamleKarakterer.Items[lstGamleKarakterer.Items.Count-1].Text)); //TODO: giver fejl hvis der ikke er en gammel karakter
			if (kampagnemanager.SætKarakterStatus(karakter, Enum.KarakterStatus.Afslået) && kampagnemanager.SætKarakterStatus(forrigekarakter, Enum.KarakterStatus.Opdateret))
			{
				btnGodkendKarakter.Enabled = false;
				btnGodkendKarakter.Visible = false;
				btnAfslåKarakter.Enabled = false;
				btnAfslåKarakter.Visible = false;
				hvdside.OpdaterLstKarakterer();
				hvdside.OpdaterLstTilmeldte();
				MessageBox.Show("Karakteren er blevet afslået", "Afslået", MessageBoxButtons.OK, MessageBoxIcon.None);
			}
			else
			{
				MessageBox.Show("Der skete en fejl og karakteren er ikke blevet afslået", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//Lavet af Thorbjørn
		public void SætAttributter()
		{
			IEnumerator attributiterator = kampagnemanager.GetAttributIterator();
			IKampagneAttribut ikampagneattribut;
			string attributværdi;
			int y = 5;
			int x = 5;

			attributiterator.Reset();
			while (attributiterator.MoveNext())
			{
				ikampagneattribut = (IKampagneAttribut)attributiterator.Current;
				attributværdi = karakter.FindAttributVærdi(ikampagneattribut.KampagneAttributID);

				Label label = new Label();
				label.Text = ikampagneattribut.Navn;
				label.Location = new Point(x, y);

				TextBox textbox = new TextBox();
				textbox.Location = new Point(100, y);
				textbox.Text = attributværdi;
				textbox.ReadOnly = true;
				if (ikampagneattribut.Type == Enum.KampagneAttributType.Multiline)
				{
					textbox.Multiline = true;
					textbox.Size = new System.Drawing.Size(150, 100);
				}

				this.Controls.Add(textbox);
				this.Controls.Add(label);
				setattributpanel.Controls.Add(textbox);
				setattributpanel.Controls.Add(label);

				y += textbox.Height + 5;
			}
		}

		//Lavet af Thorbjørn
		private void OpdaterListview()
		{
			///Hvis I ændrer i rækkefølgen her, så husk også at ændre i btnAfslåKarakter_Click metoden
			IEnumerator karakteriterator = bruger.FindGamleKarakterer(karakter);
			IKarakter gammelkarakter;
			karakteriterator.Reset();
			lstGamleKarakterer.Items.Clear();
			int version = 1;

			while (karakteriterator.MoveNext())
			{
				gammelkarakter = (IKarakter)karakteriterator.Current;
				if (gammelkarakter.Status != Enum.KarakterStatus.Afslået)
				{
					ListViewItem item = new ListViewItem();

					item.Text = Convert.ToString(gammelkarakter.KarakterID);
					item.SubItems.Add(gammelkarakter["Navn"]);
					item.SubItems.Add(version.ToString());

					lstGamleKarakterer.Items.Add(item);
					version++;
				}
			}
			lstGamleKarakterer.Sort();
		}

		//Lavet af Thorbjørn
		private void lstGamleKarakterer_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewItem valgteitem = lstGamleKarakterer.Items[lstGamleKarakterer.SelectedIndices[0]];
			long karakterID = Convert.ToInt64(valgteitem.SubItems[0].Text);
			IKarakter ikarakter = kampagnemanager.FindKarakter(karakterID);
			IBruger ibruger = kampagnemanager.FindKaraktersBruger(karakterID);
			FrmKarakter karaktervindue = new FrmKarakter(kampagnemanager, ibruger, ikarakter, hvdside);
			karaktervindue.Show();
		}
	}
}
