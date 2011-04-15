using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using BK_Controller;

namespace BK_GUI
{
    public partial class FrmLoginKampagneValg : Form
    {
        BrugerKlient brugerklient;
        public FrmLoginKampagneValg(BrugerKlient brugerklient)
        {
            InitializeComponent();
            this.brugerklient = brugerklient;
            OpdaterListView();
        }

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

        private void btnVælgKampagne_Click(object sender, EventArgs e)
        {
            FrmHovedSide frmhovedside = new FrmHovedSide(brugerklient);
            this.Hide();
            frmhovedside.ShowDialog();
            this.Close();
        }
    }
}
