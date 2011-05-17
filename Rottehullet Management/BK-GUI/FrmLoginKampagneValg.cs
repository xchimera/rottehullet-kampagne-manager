using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Interfaces;
using BK_Controller;

namespace BK_GUI
{
    public partial class FrmLoginKampagneValg : Form
    {
        BrugerKlient brugerklient;

		//Lavet af Søren
        public FrmLoginKampagneValg(BrugerKlient brugerklient)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            OpdaterListView();
        }

		//Lavet af Søren
        private void OpdaterListView()
        {
            IKampagne ikampagne;
            IEnumerator kampagneiterator = brugerklient.GetKampagneIterator();
            kampagneiterator.Reset();
            lstKampagner.Items.Clear();


            while (kampagneiterator.MoveNext())
            {
                ikampagne = (IKampagne)kampagneiterator.Current;
                ListViewItem item = new ListViewItem();


                item.Text = Convert.ToString(ikampagne.KampagneID.ToString());
                item.SubItems.Add(ikampagne.Navn);

                lstKampagner.Items.Add(item);

            }

        }

		//Lavet af Søren
        private void btnVælgKampagne_Click(object sender, EventArgs e)
        {
            if (lstKampagner.SelectedIndices.Count > 0)
			{
				ListViewItem item = lstKampagner.Items[lstKampagner.SelectedIndices[0]]; 
                
				FrmHovedSide frmhovedside = new FrmHovedSide(brugerklient, Convert.ToInt64(item.SubItems[0].Text));
				this.Hide();
				frmhovedside.ShowDialog();
				this.Close();
			}
			else
			{
				MessageBox.Show("Vælg en kampagne", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		//Lavet af Denny
		private void lstKampagner_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstKampagner.SelectedIndices.Count > 0)
            {
                ListViewItem item = lstKampagner.Items[lstKampagner.SelectedIndices[0]];

                FrmHovedSide frmhovedside = new FrmHovedSide(brugerklient, Convert.ToInt64(item.SubItems[0].Text));
                this.Hide();
                frmhovedside.ShowDialog();
                this.Close();
            }
        }

		private void btnbtnRedigerBrugerInfo_Click(object sender, EventArgs e)
		{
			FrmRetBruger frmretbruger = new FrmRetBruger(brugerklient);
			frmretbruger.ShowDialog();
		}

        private void lstKampagner_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lstKampagner.Items[lstKampagner.SelectedIndices[0]];

            IKampagne ikampagne;
            IScenarie iscenarie;
            IEnumerator kampagneiterator = brugerklient.GetKampagneIterator();
            
            kampagneiterator.Reset();
            while (kampagneiterator.MoveNext())
            {
                ikampagne = (IKampagne)kampagneiterator.Current;
                if (ikampagne.KampagneID == Convert.ToInt64(item.SubItems[0].Text))
                {
                    txtNavn.Text = ikampagne.Navn;
                    txtHjemmeside.Text = ikampagne.Hjemmeside;
                    txtBeskrivelse.Text = ikampagne.Beskrivelse;

                    iscenarie = (IScenarie)ikampagne.HentNæsteScenarie();
                    if (iscenarie != null)
                    {
                        txtNavn.Text = iscenarie.Titel;
                        txtPris.Text = iscenarie.Pris.ToString();
                        txtDato.Text = iscenarie.Tid.ToShortDateString();
                        txtScenarieBeskrivelse.Text = iscenarie.Beskrivelse;
                    }
                    else
                    {
                        txtNavn.Text = "";
                        txtPris.Text = "";
                        txtDato.Text = "";
                        txtScenarieBeskrivelse.Text = "";
                    }
                }
            }
        
        }
    }
}
