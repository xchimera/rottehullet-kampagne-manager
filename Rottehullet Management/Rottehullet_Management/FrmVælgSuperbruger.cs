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

		//Lavet af Denny
        public FrmVælgSuperbruger(KampagneManager kampagnemanager, IKampagne kampagne)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
            this.kampagne = kampagne;
            OpdaterListView();

        }

		//Lavet af Denny og Søren
        private void OpdaterListView()
        {
            IBruger ibruger;
            long superbruger;
            IEnumerator brugeriterator = kampagnemanager.GetBrugerIterator();
            IEnumerator superbrugeriterator = kampagnemanager.GetSuperbrugerIterator();
            brugeriterator.Reset();
            superbrugeriterator.Reset();
            lstBrugere.Items.Clear();
           
            while (brugeriterator.MoveNext())
            {
                ibruger = (IBruger)brugeriterator.Current;
                superbrugeriterator.Reset();
                ListViewItem brugere = new ListViewItem();
                
                if (kampagnemanager.NuværendebrugerId != ibruger.BrugerID)
                {
                    brugere.Text = ibruger.BrugerID.ToString();
                    brugere.SubItems.Add(ibruger.Navn);
                    while (superbrugeriterator.MoveNext())
                    {
                        superbruger = Convert.ToInt64(superbrugeriterator.Current);
                        if (ibruger.BrugerID == superbruger)
                        {
                            brugere.BackColor = Color.Green;
                        }
                    }
                    lstBrugere.Items.Add(brugere);
                }
            }
        }

		//Lavet af Denny og Søren
        private void btnVælgSuperbruger_Click(object sender, EventArgs e)
        {

            if (lstBrugere.SelectedIndices.Count > 0)
            {
                ListViewItem SB = lstBrugere.Items[lstBrugere.SelectedIndices[0]];

                if (SB.BackColor != Color.Green)
                {
                    if (!kampagnemanager.TilknytSuperbruger(long.Parse(SB.SubItems[0].Text), kampagne.KampagneID))
                    {
                        MessageBox.Show("Der opstod en fejl under tilknytning af superbruger", "Systemfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Brugeren er tilknyttet til kampagnen", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpdaterListView();
                    }
                }
                else
                {
                    MessageBox.Show("Du kan ikke tilknytte denne bruger som superbruger da brugeren allerede er superbruger", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vælg en bruger", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
 

        private void btnAnnuller_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFravælgSuperbruger_Click(object sender, EventArgs e)
        {
            if (lstBrugere.SelectedIndices.Count > 0)
            {
                ListViewItem item = lstBrugere.Items[lstBrugere.SelectedIndices[0]];

                if (item.BackColor == Color.Green)
                {
                    if (kampagnemanager.FravælgSuperbruger(long.Parse(item.SubItems[0].Text)))
                    {
                        MessageBox.Show("Brugeren er fravalgt som topbruger", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpdaterListView();
                    }
                    else
                    {
                        MessageBox.Show("Der opstod en fejl under fravælgelse af topbruger", "Systemfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Du kan ikke fravælge denne bruger som superbruger da brugeren ikke er superbruger for denne kampagne", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vælg venligst en bruger", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
