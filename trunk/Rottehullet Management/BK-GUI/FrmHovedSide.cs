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

        public FrmHovedSide(BrugerKlient brugerklient, long kampagneID)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            kontroller = new List<Control>();
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

        public void OpretAttributter()
        {
            IKampagneAttribut ikampagneattribut;
            IKampagneMultiAttributValgmulighed valgmulighed;
            IEnumerator attributiterator = brugerklient.GetAttributIterator(ikampagne.KampagneID);
            int y = 27;
            int x = lstkaraktere.Width + 100;
            attributiterator.Reset();

            while (attributiterator.MoveNext())
            {
                ikampagneattribut = (IKampagneAttribut)attributiterator.Current;
                if (ikampagneattribut.Type == Enum.KampagneAttributType.Singleline)
                {
                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(x , y);
                    textbox.Name = ikampagneattribut.KampagneAttributID.ToString();
                    Label label = new Label();
                    label.Text = ikampagneattribut.Navn;
                    label.Location = new Point(x - textbox.Width+50, y);
                    this.Controls.Add(textbox);
                    this.Controls.Add(label);
                    y += textbox.Height + 5;
                    kontroller.Add(textbox);
                }
                if (ikampagneattribut.Type == Enum.KampagneAttributType.Multiline)
                {
                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(x, y);
                    textbox.Multiline = true;
                    textbox.Name = ikampagneattribut.KampagneAttributID.ToString();
                    textbox.Size = new System.Drawing.Size(150, 100);
                    Label label = new Label();
                    label.Text = ikampagneattribut.Navn;
                    label.Location = new Point(x - textbox.Width+50, y);
                    y += textbox.Height + 5;
                    this.Controls.Add(textbox);
                    this.Controls.Add(label);
                    kontroller.Add(textbox);
                }
                if (ikampagneattribut.Type == Enum.KampagneAttributType.Combo)
                {
                    IEnumerator valgmulighediterator = brugerklient.GetValgmulighederIterator(ikampagneattribut.KampagneAttributID, ikampagne.KampagneID);
                    ComboBox combobox = new ComboBox();
                    combobox.Location = new Point(x, y);
                    while (valgmulighediterator.MoveNext())
                    {
                        valgmulighed = (IKampagneMultiAttributValgmulighed)valgmulighediterator.Current;
                        combobox.Items.Add(valgmulighed.Værdi);
                    }
                    combobox.Name = ikampagneattribut.KampagneAttributID.ToString();
                    Label label = new Label();
                    label.Text = ikampagneattribut.Navn;
                    label.Location = new Point(x - combobox.Width, y);
                    label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    y += combobox.Height + 5;
                    this.Controls.Add(combobox);
                    this.Controls.Add(label);
                    kontroller.Add(combobox);
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
            FrmScenarieTilmelding scenarietilmelding = new FrmScenarieTilmelding();
            this.Hide();
            scenarietilmelding.ShowDialog();
            this.Show();
        }

        private void btnNyKarakter_Click(object sender, EventArgs e)
        {
            btnNyOpdaterDisabled.Text = "Indsend karakter";
            OpretAttributter();
            btnNyKarakter.Enabled = false;
        }

        private void lstkaraktere_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnNyOpdaterDisabled.Text = "Opdater karakter"; 
        }

        private void btnNyOpdaterDisabled_Click(object sender, EventArgs e)
        {
            if (btnNyOpdaterDisabled.Text == "Indsend karakter")
            {
                if (brugerklient.NyKarakter(kontroller.GetEnumerator()))
                {
                    MessageBox.Show("Brugeren er oprettet");
                }
                else
                {
                    MessageBox.Show("Der skete en fejl under oprettelse af brugeren", "Fejl under oprettelse af bruger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnNyOpdaterDisabled.Text == "Opdater karakter")
            {

            }

        }
    }
}
