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


        public FrmHovedSide(BrugerKlient brugerklient, long kampagneID)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            kontroller = new List<Control>();
            listvalgID = new List<List<long>>();
            ikampagne = brugerklient.FindKampagne(kampagneID);
            OpdaterListView();
        }
        public void OpdaterListView()
        {
            IKarakter ikarakter;
            IEnumerator karakteriterator = brugerklient.GetKarakterIterator();

            karakteriterator.Reset();
            lstkaraktere.Items.Clear();


            while (karakteriterator.MoveNext())
            {
                ikarakter = (IKarakter)karakteriterator.Current;
                ListViewItem item = new ListViewItem();

                if (ikarakter.Kampagne.KampagneID == ikampagne.KampagneID)
                {
                    item.Text = ikarakter.KarakterID.ToString();
                    item.SubItems.Add(ikarakter["Navn"]);
                    lstkaraktere.Items.Add(item);
                }

            }
        }

        private void lstKarakter_DoubleClick(object sender, EventArgs e)
        {

            // user clicked an item of listview control

            if (lstkaraktere.SelectedItems.Count == 1)
            {//display the text of selected item

                MessageBox.Show(lstkaraktere.SelectedItems[0].Text);

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
                    combobox.Location = new Point(x + label.Width +10, y);
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

				FrmScenarieTilmelding scenarietilmelding = new FrmScenarieTilmelding(brugerklient, int.Parse(lstkaraktere.SelectedItems[0].Text), scenarie);
				this.Hide();
				scenarietilmelding.ShowDialog();
				this.Show();
			}
			else
			{
				MessageBox.Show("Du skal vælge en karakter, før du trykker på denne knap", "Ingen karakter valgt");
			}
        }
        private void btnNyKarakter_Click(object sender, EventArgs e)
        {
            btnNyOpdaterDisabled.Text = "Indsend karakter";
            OpretAttributter();
            btnNyKarakter.Enabled = false;
        }
        private void lstkaraktere_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FjernKontroler();
            SetAttributter();
            btnNyOpdaterDisabled.Text = "Opdater karakter";
            btnNyOpdaterDisabled.Enabled = true;
        }
        //todo: og her
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
                    label.Text = ikarakterattribut.Kampagneattribut.Navn;

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
                    label.Text = ikarakterattribut.Kampagneattribut.Navn;
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
                    label.Text = værdi.Current.ToString();
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

        void btnNyOpdaterDisabled_Click(object sender, EventArgs e)
        {
            if (btnNyOpdaterDisabled.Text == "Indsend karakter")
            {
                if (brugerklient.NyKarakter(kontroller.GetEnumerator(), listvalgID.GetEnumerator(), KarakterStatus.Nyoprettet))
                {
                    MessageBox.Show("Brugeren er oprettet");
                    FjernKontroler();
                    OpdaterListView();
                }
                else
                {
                    MessageBox.Show("Der skete en fejl under oprettelse af brugeren", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnNyOpdaterDisabled.Text == "Opdater karakter")
            {
                ListViewItem item = lstkaraktere.Items[lstkaraktere.SelectedIndices[0]];
                if (brugerklient.OpdaterKarakter(kontroller.GetEnumerator(), listvalgID.GetEnumerator(), Convert.ToInt64(item.SubItems[0].Text), KarakterStatus.Opdateret))
                {
                    MessageBox.Show("Brugeren er opdateret", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FjernKontroler();
                }
                else
                {
                    MessageBox.Show("Der skete en fejl under opdateringen af brugeren", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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
            btnNyOpdaterDisabled.Enabled = false;
            btnNyKarakter.Enabled = true;
        }

       

    }
}
