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
	public partial class DatabaseOpsætning : Form
	{
		DatabaseController contr;

		public DatabaseOpsætning()
		{
			InitializeComponent();
			contr = new DatabaseController();
		}

		//Lavet af Thorbjørn
		private void btnOpdaterDatabase_Click(object sender, EventArgs e)
		{
			DialogResult dialogue = MessageBox.Show("Er du sikker på du vil opdatere database filen?", "Databaseopdatering", MessageBoxButtons.YesNo);
			if (dialogue == DialogResult.Yes)
			{
				string databasestreng = "Data Source= " + txtDataSource.Text + ";Initial Catalog=" + txtCatalogue.Text + ";User Id=" + txtUserID.Text + ";Password=" + txtPassword.Text;
				if (contr.RetDatabaseFil(databasestreng))
				{
					MessageBox.Show("Der er blevet oprettet en ny databasefil (data.dat). Sørg for at alle som bruger programmet får den.", "Databaseopdatering");
					this.Close();
				}
				else
				{
					MessageBox.Show("Der skete en fejl, da den nye databasefil skulle oprettes.", "System fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
