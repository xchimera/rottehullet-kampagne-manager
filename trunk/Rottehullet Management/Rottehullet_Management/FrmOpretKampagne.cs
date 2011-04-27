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
using Controller;

namespace Rottehullet_Management
{
    public partial class FrmOpretKampagne : Form
    {
        KampagneManager kampagnemanager;
        public FrmOpretKampagne(KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
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

                brugere.Text = ibruger.BrugerID.ToString();
                brugere.SubItems.Add(ibruger.Navn);

                lstBrugere.Items.Add(brugere);
            }
        }

        private void Opret_kampagne_Load(object sender, EventArgs e)
        {
            OpdaterListView();
        }

        private void txtSøgBruger_TextChanged(object sender, EventArgs e)
        {
            IBruger ibruger;
            IEnumerator brugeriterator = kampagnemanager.GetBrugerIterator();
            string text;

            if (txtSøgBruger.Text == "")
            {
                OpdaterListView();
                return;
            }

            brugeriterator.Reset();
            lstBrugere.Items.Clear();

            while (brugeriterator.MoveNext())
            {
                ibruger = (IBruger)brugeriterator.Current;
                text = txtSøgBruger.Text.ToString();

                if (Convert.ToString((ibruger.BrugerID)).ToUpper().IndexOf(text.ToUpper()) != -1 || (ibruger.Navn).ToUpper().IndexOf(text.ToUpper()) != -1)
                {
                    ListViewItem brugere = new ListViewItem();

                    brugere.Text = ibruger.BrugerID.ToString();
                    brugere.SubItems.Add(ibruger.Navn);

                    lstBrugere.Items.Add(brugere);
                }
            }
        }

        private void btnOpretKampagne_Click(object sender, EventArgs e)
        {
			if (lstBrugere.SelectedIndices.Count == 0)
			{
				MessageBox.Show("Vælg venligst en bruger", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else if (txtKampagneNavn.Text == "")
			{
				MessageBox.Show("Kampagnen skal have et navn", "Brugerfejl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			int index = lstBrugere.SelectedIndices[0];
            ListViewItem item = lstBrugere.Items[index];

            if (kampagnemanager.OpretKampagne(txtKampagneNavn.Text, Convert.ToInt64(item.SubItems[0].Text)))
            {
                MessageBox.Show("Kampagnen " + txtKampagneNavn.Text + " er oprettet");
                this.Close();
            }
            else
            {
                MessageBox.Show("Kampagnen " + txtKampagneNavn.Text + " kunne ikke oprettes", "Fejl i System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
