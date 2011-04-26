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
        List<string[]> kampagneliste;
        
        public FrmLoginKampagneValg(KampagneManager kampagnemanager)
		{
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
            kampagneliste = new List<string[]>();
            OpdaterListView();			
		}

        private void OpdaterListView()
        {
            string[] kampagne;
            IEnumerator kampagneiterator = kampagnemanager.GetBrugerKampagne();
            kampagneiterator.Reset();
            lstKampagner.Items.Clear();
            

            while (kampagneiterator.MoveNext())
            {
                kampagne = (string[])kampagneiterator.Current;
                ListViewItem item = new ListViewItem();


                item.Text = Convert.ToString(kampagne[0]);
                item.SubItems.Add(Convert.ToString(kampagne[1]));

                lstKampagner.Items.Add(item);
            }
			lstKampagner.Items[0].Selected = true;
        }


		//private void startKampagne(long kampagneID, string navn)
		//{
		//    if (kampagnemanager.HentKampagneFraDatabase(kampagneID))
		//    {
		//        FrmHovedside hovedside = new FrmHovedside(navn, kampagnemanager);
		//        this.Hide();
		//        hovedside.ShowDialog();
		//        this.Close();
		//    }
		//    else
		//    {
		//        MessageBox.Show("Der skete en fejl under adgangen til denne kampagne.");
		//    }
		//}

        private void btnVælgKampagne_Click(object sender, EventArgs e)
        {
			if (lstKampagner.SelectedIndices.Count > 0)
			{
				ListViewItem item = lstKampagner.Items[lstKampagner.SelectedIndices[0]];

				if (kampagnemanager.HentKampagneFraDatabase(Convert.ToInt64(item.SubItems[0].Text)))
				{
					FrmHovedside hovedside = new FrmHovedside(item.SubItems[1].Text, kampagnemanager);
					this.Hide();
					hovedside.ShowDialog();
					this.Close();
				}
				else
				{
					MessageBox.Show("Der skete en fejl ved indlæsningen af denne kampagne", "Databasefejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Vælg en kampagne", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
           
        }
	}
}
