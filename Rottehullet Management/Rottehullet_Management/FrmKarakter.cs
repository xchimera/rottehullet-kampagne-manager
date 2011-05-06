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
		
		public FrmKarakter(KampagneManager kampagnemanager, IBruger bruger, IKarakter karakter, FrmHovedside hovedside)
		{
			InitializeComponent();
			this.kampagnemanager = kampagnemanager;
			this.bruger = bruger;
			this.karakter = karakter;
			this.hvdside = hovedside;
			txtNavn.Text = bruger.Navn;
			txtAlder.Text = (DateTime.Now.Year - bruger.Fødselsdag.Year).ToString();
			txtEmail.Text = bruger.Email;
			txtTelefon.Text = bruger.Tlf.ToString();
			txtKontaktperson.Text = bruger.NødTlf.ToString();
			this.Text = karakter["Navn"];

			SætAttributter();
			OpdaterListview();

			if (karakter.Status == Enum.KarakterStatus.Nyoprettet || karakter.Status == Enum.KarakterStatus.Opdateret)
			{
				btnGodkendKarakter.Enabled = true;
				btnGodkendKarakter.Visible = true;
				btnAfslåKarakter.Enabled = true;
				btnAfslåKarakter.Visible = true;
			}
		}

		private void btnGodkendKarakter_Click(object sender, EventArgs e)
		{
			if (kampagnemanager.SætKarakterStatus(karakter, Enum.KarakterStatus.Godkendt))
			{
				string test = karakter.Status.ToString();
				MessageBox.Show(test, "Godkendt", MessageBoxButtons.OK, MessageBoxIcon.None);
				btnGodkendKarakter.Enabled = false;
				btnGodkendKarakter.Visible = false;
				btnAfslåKarakter.Enabled = false;
				btnAfslåKarakter.Visible = false;
			}
			else
			{
				MessageBox.Show("Der skete en fejl og karakteren er ikke blevet godkendt", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAfslåKarakter_Click(object sender, EventArgs e)
		{
			if (kampagnemanager.SætKarakterStatus(karakter, Enum.KarakterStatus.Afslået))
			{
				MessageBox.Show("Karakteren er blevet afslået", "Afslået", MessageBoxButtons.OK, MessageBoxIcon.None);
				btnGodkendKarakter.Enabled = false;
				btnGodkendKarakter.Visible = false;
				btnAfslåKarakter.Enabled = false;
				btnAfslåKarakter.Visible = false;
			}
			else
			{
				MessageBox.Show("Der skete en fejl og karakteren er ikke blevet afslået", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

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

		private void OpdaterListview()
		{
			IEnumerator karakteriterator = bruger.FindGamleKarakterer(karakter);
			karakteriterator.Reset();
			lstGamleKarakterer.Items.Clear();
			int version = 1;

			while (karakteriterator.MoveNext())
			{
				karakter = (IKarakter)karakteriterator.Current;
				ListViewItem item = new ListViewItem();

				item.Text = Convert.ToString(karakter.KarakterID);
				item.SubItems.Add(karakter["Navn"]);
				item.SubItems.Add(version.ToString());

				lstGamleKarakterer.Items.Add(item);
				version++;
			}
			lstGamleKarakterer.Sort();
		}

		private void lstGamleKarakterer_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewItem valgteitem = lstGamleKarakterer.Items[lstGamleKarakterer.SelectedIndices[0]];
			long karakterID = Convert.ToInt64(valgteitem.SubItems[0].Text);
			IKarakter ikarakter = kampagnemanager.FindKarakter(karakterID);
			IBruger ibruger = kampagnemanager.FindKaraktersBruger(karakterID);
			FrmKarakter karaktervindue = new FrmKarakter(kampagnemanager, ibruger, ikarakter, hvdside);
			karaktervindue.ShowDialog();
		}
	}
}
