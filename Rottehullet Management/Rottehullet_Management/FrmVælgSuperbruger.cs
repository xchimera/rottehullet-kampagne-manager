using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Controller;
using Interfaces;

namespace Rottehullet_Management
{
    public partial class FrmVælgSuperbruger : Form
    {
        KampagneManager kampagnemanager;
        IKampagne kampagne;
        public FrmVælgSuperbruger(KampagneManager kampagnemanager, IKampagne kampagne)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
            this.kampagne = kampagne;
            OpdaterListView();
        }

        private void OpdaterListView()
        {
            IBruger ibruger;
            IEnumerator brugeriterator = kampagnemanager.GetBrugerIterator();
            brugeriterator.Reset();
            lstBrugere.Items.Clear();

            while (brugeriterator.MoveNext())
            {
                ibruger = (IBruger)brugeriterator.Current;
                ListViewItem brugere = new ListViewItem();

                if (kampagnemanager.NuværendebrugerId != ibruger.BrugerID)
                {
                    brugere.Text = ibruger.BrugerID.ToString();
                    brugere.SubItems.Add(ibruger.Navn);

                    lstBrugere.Items.Add(brugere);
                }
            }
        }


        private void btnVælgSuperbruger_Click(object sender, EventArgs e)
        {
            int index = lstBrugere.SelectedIndices[0];
            ListViewItem SB = lstBrugere.SelectedItems[index];
            if (lstBrugere.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vælg venligst en bruger", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kampagnemanager.TilknytSuperbruger(long.Parse(SB.SubItems[0].Text), kampagne.KampagneID))
            {
                MessageBox.Show("Der opstod en fejl under tilknytning af superbruger", "Systemfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Brugeren er tilknyttet til kampagnen", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
 

        private void btnAnnuller_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
