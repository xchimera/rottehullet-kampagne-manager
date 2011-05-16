namespace Rottehullet_Management
{
	partial class FrmVælgSuperbruger
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lstBrugere = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVælgSuperbruger = new System.Windows.Forms.Button();
            this.btnAnnuller = new System.Windows.Forms.Button();
            this.btnFravælgSuperbruger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBrugere
            // 
            this.lstBrugere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstBrugere.FullRowSelect = true;
            this.lstBrugere.Location = new System.Drawing.Point(47, 38);
            this.lstBrugere.Name = "lstBrugere";
            this.lstBrugere.Size = new System.Drawing.Size(258, 259);
            this.lstBrugere.TabIndex = 0;
            this.lstBrugere.UseCompatibleStateImageBehavior = false;
            this.lstBrugere.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Navn";
            this.columnHeader2.Width = 254;
            // 
            // btnVælgSuperbruger
            // 
            this.btnVælgSuperbruger.Location = new System.Drawing.Point(47, 330);
            this.btnVælgSuperbruger.Name = "btnVælgSuperbruger";
            this.btnVælgSuperbruger.Size = new System.Drawing.Size(133, 23);
            this.btnVælgSuperbruger.TabIndex = 1;
            this.btnVælgSuperbruger.Text = "Vælg superbruger";
            this.btnVælgSuperbruger.UseVisualStyleBackColor = true;
            this.btnVælgSuperbruger.Click += new System.EventHandler(this.btnVælgSuperbruger_Click);
            // 
            // btnAnnuller
            // 
            this.btnAnnuller.Location = new System.Drawing.Point(143, 359);
            this.btnAnnuller.Name = "btnAnnuller";
            this.btnAnnuller.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuller.TabIndex = 2;
            this.btnAnnuller.Text = "Luk";
            this.btnAnnuller.UseVisualStyleBackColor = true;
            this.btnAnnuller.Click += new System.EventHandler(this.btnAnnuller_Click);
            // 
            // btnFravælgSuperbruger
            // 
            this.btnFravælgSuperbruger.Location = new System.Drawing.Point(186, 330);
            this.btnFravælgSuperbruger.Name = "btnFravælgSuperbruger";
            this.btnFravælgSuperbruger.Size = new System.Drawing.Size(119, 23);
            this.btnFravælgSuperbruger.TabIndex = 3;
            this.btnFravælgSuperbruger.Text = "Fravælg superbruger";
            this.btnFravælgSuperbruger.UseVisualStyleBackColor = true;
            this.btnFravælgSuperbruger.Click += new System.EventHandler(this.btnFravælgSuperbruger_Click);
            // 
            // FrmVælgSuperbruger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 428);
            this.Controls.Add(this.btnFravælgSuperbruger);
            this.Controls.Add(this.btnAnnuller);
            this.Controls.Add(this.btnVælgSuperbruger);
            this.Controls.Add(this.lstBrugere);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVælgSuperbruger";
            this.Text = "Vælg superbruger";
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ListView lstBrugere;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnVælgSuperbruger;
        private System.Windows.Forms.Button btnAnnuller;
        private System.Windows.Forms.Button btnFravælgSuperbruger;
	}
}