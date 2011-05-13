using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using InputBox;

namespace Rottehullet_Management
{
    public partial class FrmAdminSektion : Form
    {
        KampagneManager kampagnemanager;

        public FrmAdminSektion(KampagneManager kampagnemanager)
        {
            InitializeComponent();
            this.kampagnemanager = kampagnemanager;
        }

		//Lavet af Søren
		private void btnOpretKampagne_Click(object sender, EventArgs e)
        {
            FrmOpretKampagne frmopretkampagne = new FrmOpretKampagne(kampagnemanager);
            frmopretkampagne.ShowDialog();

        }

		private void btnAdminkode_Click(object sender, EventArgs e)
		{
			InputBoxSingleline singleline = new InputBoxSingleline("","Nyt Adminkodeord");
			singleline.ShowDialog();
			if (singleline.Lastbutton == 1)
            {
                if (MessageBox.Show("Vil du ændre kodeord?", "Kodeordsændring", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (kampagnemanager.RetAdminKodeord(singleline.Text))
					{
						string messageboxtext = "Adminkodeordet er blevet rettet til: "+(singleline.Text);
						MessageBox.Show(messageboxtext, "Kodeord Rettet");
					}
					else
					{
						MessageBox.Show("Der skete en fejl, da elementet skulle slettes i databasen.", "Database fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
    }
}
