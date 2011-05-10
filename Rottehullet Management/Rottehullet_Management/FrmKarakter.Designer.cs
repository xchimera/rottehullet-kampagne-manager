namespace Rottehullet_Management
{
	partial class FrmKarakter
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtNavn = new System.Windows.Forms.TextBox();
			this.txtAlder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTelefon = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtKontaktperson = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnGodkendKarakter = new System.Windows.Forms.Button();
			this.btnAfslåKarakter = new System.Windows.Forms.Button();
			this.lstGamleKarakterer = new System.Windows.Forms.ListView();
			this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colKarakterNavn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.setattributpanel = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Navn";
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(88, 25);
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.ReadOnly = true;
			this.txtNavn.Size = new System.Drawing.Size(100, 20);
			this.txtNavn.TabIndex = 1;
			// 
			// txtAlder
			// 
			this.txtAlder.Location = new System.Drawing.Point(88, 51);
			this.txtAlder.Name = "txtAlder";
			this.txtAlder.ReadOnly = true;
			this.txtAlder.Size = new System.Drawing.Size(100, 20);
			this.txtAlder.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Alder";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(88, 77);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.ReadOnly = true;
			this.txtEmail.Size = new System.Drawing.Size(100, 20);
			this.txtEmail.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Email";
			// 
			// txtTelefon
			// 
			this.txtTelefon.Location = new System.Drawing.Point(88, 103);
			this.txtTelefon.Name = "txtTelefon";
			this.txtTelefon.ReadOnly = true;
			this.txtTelefon.Size = new System.Drawing.Size(100, 20);
			this.txtTelefon.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Telefon";
			// 
			// txtKontaktperson
			// 
			this.txtKontaktperson.Location = new System.Drawing.Point(88, 129);
			this.txtKontaktperson.Name = "txtKontaktperson";
			this.txtKontaktperson.ReadOnly = true;
			this.txtKontaktperson.Size = new System.Drawing.Size(100, 20);
			this.txtKontaktperson.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Kontaktperson";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtKontaktperson);
			this.groupBox1.Controls.Add(this.txtNavn);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTelefon);
			this.groupBox1.Controls.Add(this.txtAlder);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtEmail);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 158);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Spiller";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 181);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Karakter";
			// 
			// btnGodkendKarakter
			// 
			this.btnGodkendKarakter.Enabled = false;
			this.btnGodkendKarakter.Location = new System.Drawing.Point(95, 176);
			this.btnGodkendKarakter.Name = "btnGodkendKarakter";
			this.btnGodkendKarakter.Size = new System.Drawing.Size(122, 23);
			this.btnGodkendKarakter.TabIndex = 12;
			this.btnGodkendKarakter.Text = "Godkend Opgradering";
			this.btnGodkendKarakter.UseVisualStyleBackColor = true;
			this.btnGodkendKarakter.Visible = false;
			this.btnGodkendKarakter.Click += new System.EventHandler(this.btnGodkendKarakter_Click);
			// 
			// btnAfslåKarakter
			// 
			this.btnAfslåKarakter.Enabled = false;
			this.btnAfslåKarakter.Location = new System.Drawing.Point(223, 176);
			this.btnAfslåKarakter.Name = "btnAfslåKarakter";
			this.btnAfslåKarakter.Size = new System.Drawing.Size(117, 23);
			this.btnAfslåKarakter.TabIndex = 13;
			this.btnAfslåKarakter.Text = "Afslå Karakter";
			this.btnAfslåKarakter.UseVisualStyleBackColor = true;
			this.btnAfslåKarakter.Visible = false;
			this.btnAfslåKarakter.Click += new System.EventHandler(this.btnAfslåKarakter_Click);
			// 
			// lstGamleKarakterer
			// 
			this.lstGamleKarakterer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colKarakterNavn,
            this.colVersion});
			this.lstGamleKarakterer.FullRowSelect = true;
			this.lstGamleKarakterer.Location = new System.Drawing.Point(12, 396);
			this.lstGamleKarakterer.Name = "lstGamleKarakterer";
			this.lstGamleKarakterer.Size = new System.Drawing.Size(328, 97);
			this.lstGamleKarakterer.TabIndex = 14;
			this.lstGamleKarakterer.UseCompatibleStateImageBehavior = false;
			this.lstGamleKarakterer.View = System.Windows.Forms.View.Details;
			this.lstGamleKarakterer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstGamleKarakterer_MouseDoubleClick);
			// 
			// colID
			// 
			this.colID.Text = "";
			this.colID.Width = 0;
			// 
			// colKarakterNavn
			// 
			this.colKarakterNavn.Text = "Gamle Versioner";
			this.colKarakterNavn.Width = 264;
			// 
			// colVersion
			// 
			this.colVersion.Text = "Version";
			// 
			// setattributpanel
			// 
			this.setattributpanel.AutoScroll = true;
			this.setattributpanel.Location = new System.Drawing.Point(12, 205);
			this.setattributpanel.Name = "setattributpanel";
			this.setattributpanel.Size = new System.Drawing.Size(328, 176);
			this.setattributpanel.TabIndex = 15;
			// 
			// FrmKarakter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(347, 505);
			this.Controls.Add(this.setattributpanel);
			this.Controls.Add(this.lstGamleKarakterer);
			this.Controls.Add(this.btnAfslåKarakter);
			this.Controls.Add(this.btnGodkendKarakter);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox1);
			this.Name = "FrmKarakter";
			this.Text = "Karakter";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.TextBox txtAlder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTelefon;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtKontaktperson;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnGodkendKarakter;
		private System.Windows.Forms.Button btnAfslåKarakter;
		private System.Windows.Forms.ListView lstGamleKarakterer;
		private System.Windows.Forms.ColumnHeader colID;
		private System.Windows.Forms.ColumnHeader colKarakterNavn;
		private System.Windows.Forms.Panel setattributpanel;
		private System.Windows.Forms.ColumnHeader colVersion;
	}
}