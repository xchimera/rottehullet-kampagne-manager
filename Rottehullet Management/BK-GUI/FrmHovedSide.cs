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
        private long kampagneID;
        IKampagne ikampagne;

        public FrmHovedSide(BrugerKlient brugerklient, long kampagneID)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            this.kampagneID = kampagneID;
            OpdaterListView();
            OpretAttributter();
            
        }

        public void OpdaterListView()
        {
            IKarakter ikarakter;
            IKarakter iværdi;
            IEnumerator karakteriterator = brugerklient.GetKarakterIterator();
            
            karakteriterator.Reset();
            lstkaraktere.Items.Clear();
            

            while (karakteriterator.MoveNext())
            {
                ikarakter = (IKarakter)karakteriterator.Current;
                iværdi = (IKarakter)ikarakter.GetVærdiIterator();
                ListViewItem item = new ListViewItem();

                if (ikarakter.Kampagne.KampagneID == ikampagne.KampagneID)
                {
                    item.Text = ikarakter.KarakterID.ToString();
                    item.SubItems.Add(ikarakter["navn"]);
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
            int x = lstkaraktere.Width + 10;
            attributiterator.Reset();

            while (attributiterator.MoveNext())
            {
                ikampagneattribut = (IKampagneAttribut)attributiterator.Current;
                if (ikampagneattribut.Type == Enum.KampagneAttributType.Singleline)
                {
                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(x , y);
                    y += textbox.Height + 5;
                }
                if (ikampagneattribut.Type == Enum.KampagneAttributType.Multiline)
                {
                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(x, y);
                    textbox.Multiline = true;
                    y += textbox.Height + 5;
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
                    y += combobox.Height + 5;
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
    }
}
