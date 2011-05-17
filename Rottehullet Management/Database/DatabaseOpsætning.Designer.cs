namespace Database
{
	partial class DatabaseOpsætning
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
			this.btnOpdaterDatabase = new System.Windows.Forms.Button();
			this.btnAnnuller = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.txtDataSource = new System.Windows.Forms.TextBox();
			this.txtCatalogue = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFyldDatabase = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpdaterDatabase
			// 
			this.btnOpdaterDatabase.Location = new System.Drawing.Point(20, 118);
			this.btnOpdaterDatabase.Name = "btnOpdaterDatabase";
			this.btnOpdaterDatabase.Size = new System.Drawing.Size(75, 36);
			this.btnOpdaterDatabase.TabIndex = 14;
			this.btnOpdaterDatabase.Text = "Skab Databasefil";
			this.btnOpdaterDatabase.UseVisualStyleBackColor = true;
			this.btnOpdaterDatabase.Click += new System.EventHandler(this.btnOpdaterDatabase_Click);
			// 
			// btnAnnuller
			// 
			this.btnAnnuller.Location = new System.Drawing.Point(182, 118);
			this.btnAnnuller.Name = "btnAnnuller";
			this.btnAnnuller.Size = new System.Drawing.Size(75, 36);
			this.btnAnnuller.TabIndex = 15;
			this.btnAnnuller.Text = "Afslut";
			this.btnAnnuller.UseVisualStyleBackColor = true;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(101, 92);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(171, 20);
			this.txtPassword.TabIndex = 12;
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(101, 65);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(171, 20);
			this.txtUserID.TabIndex = 11;
			// 
			// txtDataSource
			// 
			this.txtDataSource.Location = new System.Drawing.Point(101, 12);
			this.txtDataSource.Name = "txtDataSource";
			this.txtDataSource.Size = new System.Drawing.Size(171, 20);
			this.txtDataSource.TabIndex = 7;
			// 
			// txtCatalogue
			// 
			this.txtCatalogue.Location = new System.Drawing.Point(101, 38);
			this.txtCatalogue.Name = "txtCatalogue";
			this.txtCatalogue.Size = new System.Drawing.Size(171, 20);
			this.txtCatalogue.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Password";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "User ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Initial Catalogue";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Data Source";
			// 
			// btnFyldDatabase
			// 
			this.btnFyldDatabase.Location = new System.Drawing.Point(101, 118);
			this.btnFyldDatabase.Name = "btnFyldDatabase";
			this.btnFyldDatabase.Size = new System.Drawing.Size(75, 35);
			this.btnFyldDatabase.TabIndex = 16;
			this.btnFyldDatabase.Text = "Fyld Database";
			this.btnFyldDatabase.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 164);
			this.Controls.Add(this.btnFyldDatabase);
			this.Controls.Add(this.btnOpdaterDatabase);
			this.Controls.Add(this.btnAnnuller);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserID);
			this.Controls.Add(this.txtDataSource);
			this.Controls.Add(this.txtCatalogue);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpdaterDatabase;
		private System.Windows.Forms.Button btnAnnuller;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.TextBox txtDataSource;
		private System.Windows.Forms.TextBox txtCatalogue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFyldDatabase;
	}
}

