using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Database
{
	public partial class FrmDatabaseOpsætning : Form
	{
		DatabaseController contr;

		public FrmDatabaseOpsætning()
		{
			InitializeComponent();
			contr = new DatabaseController();
			string[] databasevariable = contr.HentDatabaseVariable();//Henter database variablene fra data.dat
			if (databasevariable!=null)
			{
				txtDataSource.Text = databasevariable[0];
				txtCatalogue.Text = databasevariable[1];
				txtUserID.Text = databasevariable[2];
				txtPassword.Text = databasevariable[3];
			}			
		}

		//Lavet af Thorbjørn
		private void btnOpdaterDatabase_Click(object sender, EventArgs e)
		{
			DialogResult dialogue = MessageBox.Show("Er du sikker på du vil opdatere database filen?", "Databaseopdatering", MessageBoxButtons.YesNo);
			if (dialogue == DialogResult.Yes)
			{
				if (contr.RetDatabaseFil(txtDataSource.Text, txtCatalogue.Text, txtUserID.Text, txtPassword.Text))
				{
					MessageBox.Show("Der er blevet oprettet en ny databasefil (data.dat). Sørg for at alle som bruger programmet får den.", "Databaseopdatering");
				}
				else
				{
					MessageBox.Show("Der skete en fejl, da den nye databasefil skulle oprettes.", "System fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		//Lavet af Thorbjørn
		private void btnFyldDatabase_Click(object sender, EventArgs e)
		{
			int fejlmeddelelse = contr.FyldDatabase(txtDataSource.Text, txtCatalogue.Text, txtUserID.Text, txtPassword.Text);
			if (fejlmeddelelse == 0)
			{
				MessageBox.Show("Databasen er blevet klargjort til brug.", "Databaseopdatering");
			}
			else if(fejlmeddelelse == 1)
			{
				MessageBox.Show("Der skete en fejl, da databasen skulle klargøres.", "Database fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAnnuller_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
