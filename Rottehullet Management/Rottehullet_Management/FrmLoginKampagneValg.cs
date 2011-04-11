using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces;
using Controller;

namespace Rottehullet_Management
{
	public partial class FrmLoginKampagneValg : Form
	{
		KampagneManager kampagnemanager;

        Button button;
        
        public FrmLoginKampagneValg(KampagneManager kampagnemanager)
		{
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
            OpdaterListView();			
		}

        private void OpdaterListView()
        {
            IKampagne ikampagne;
            IEnumerator kampagneiterator = kampagnemanager.GetBrugersKampagneIterator();
            kampagneiterator.Reset();
            lstKampagner.Items.Clear();

            while (kampagneiterator.MoveNext())
            {
                ikampagne = (IKampagne)kampagneiterator.Current;
                ListViewItem kampagner = new ListViewItem();

                kampagner.Text = ikampagne.KampagneID.ToString();
                kampagner.SubItems.Add(ikampagne.Navn);

                lstKampagner.Items.Add(kampagner);
            }
        }


		private void startKampagne(long kampagneID, string navn)
		{
			if (kampagnemanager.HentKampagneFraDatabase(kampagneID))
			{
				FrmHovedside hovedside = new FrmHovedside(navn, kampagnemanager);
				this.Hide();
				hovedside.ShowDialog();
				this.Close();
			}
			else
			{
				MessageBox.Show("Der skete en fejl under adgangen til denne kampagne.");
			}
		}

        private void btnVælgKampagne_Click(object sender, EventArgs e)
        {
            ListViewItem item = lstKampagner.Items[lstKampagner.SelectedIndices[0]];

            if (kampagnemanager.HentKampagneFraDatabase(Convert.ToInt64(item.SubItems[0].Text)))
            {
                FrmHovedside hovedside = new FrmHovedside(item.SubItems[1].Text, kampagnemanager);
                this.Hide();
                hovedside.ShowDialog();
                this.Close();
            }
        }
	}
}
