namespace Rottehullet_Management
{
	partial class FrmOpstartScenarie
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
			this.dtpTid = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSted = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPris = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtBeskrivelse = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkOvernatning = new System.Windows.Forms.CheckBox();
			this.chkOvernatningTvungen = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtAntalDage = new System.Windows.Forms.MaskedTextBox();
			this.chkSpisningTvungen = new System.Windows.Forms.CheckBox();
			this.chkSpisning = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnOpret = new System.Windows.Forms.Button();
			this.btnAnnuller = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Navn:";
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(86, 12);
			this.txtNavn.MaxLength = 50;
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.Size = new System.Drawing.Size(200, 20);
			this.txtNavn.TabIndex = 1;
			// 
			// dtpTid
			// 
			this.dtpTid.CustomFormat = "dd-MM-yyyy                     kl. HH:mm";
			this.dtpTid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTid.Location = new System.Drawing.Point(86, 38);
			this.dtpTid.Name = "dtpTid";
			this.dtpTid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dtpTid.ShowUpDown = true;
			this.dtpTid.Size = new System.Drawing.Size(200, 20);
			this.dtpTid.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tidspunkt:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Sted:";
			// 
			// txtSted
			// 
			this.txtSted.Location = new System.Drawing.Point(86, 65);
			this.txtSted.MaxLength = 50;
			this.txtSted.Name = "txtSted";
			this.txtSted.Size = new System.Drawing.Size(78, 20);
			this.txtSted.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(170, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Pris:";
			// 
			// txtPris
			// 
			this.txtPris.Location = new System.Drawing.Point(203, 65);
			this.txtPris.Mask = "00000.00";
			this.txtPris.Name = "txtPris";
			this.txtPris.Size = new System.Drawing.Size(83, 20);
			this.txtPris.TabIndex = 7;
			this.txtPris.Text = "0000000";
			this.txtPris.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 92);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Beskrivelse:";
			// 
			// txtBeskrivelse
			// 
			this.txtBeskrivelse.Location = new System.Drawing.Point(12, 109);
			this.txtBeskrivelse.MaxLength = 4000;
			this.txtBeskrivelse.Multiline = true;
			this.txtBeskrivelse.Name = "txtBeskrivelse";
			this.txtBeskrivelse.Size = new System.Drawing.Size(274, 147);
			this.txtBeskrivelse.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 287);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Overnatning:";
			// 
			// chkOvernatning
			// 
			this.chkOvernatning.AutoSize = true;
			this.chkOvernatning.Location = new System.Drawing.Point(99, 287);
			this.chkOvernatning.Name = "chkOvernatning";
			this.chkOvernatning.Size = new System.Drawing.Size(15, 14);
			this.chkOvernatning.TabIndex = 11;
			this.chkOvernatning.UseVisualStyleBackColor = true;
			this.chkOvernatning.CheckedChanged += new System.EventHandler(this.chkOvernatning_CheckedChanged);
			// 
			// chkOvernatningTvungen
			// 
			this.chkOvernatningTvungen.AutoSize = true;
			this.chkOvernatningTvungen.Enabled = false;
			this.chkOvernatningTvungen.Location = new System.Drawing.Point(173, 287);
			this.chkOvernatningTvungen.Name = "chkOvernatningTvungen";
			this.chkOvernatningTvungen.Size = new System.Drawing.Size(15, 14);
			this.chkOvernatningTvungen.TabIndex = 12;
			this.chkOvernatningTvungen.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(87, 263);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Tilvalg";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(156, 263);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Tvungen";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(229, 263);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "Antal";
			// 
			// txtAntalDage
			// 
			this.txtAntalDage.Enabled = false;
			this.txtAntalDage.Location = new System.Drawing.Point(232, 284);
			this.txtAntalDage.Mask = "00";
			this.txtAntalDage.Name = "txtAntalDage";
			this.txtAntalDage.Size = new System.Drawing.Size(28, 20);
			this.txtAntalDage.TabIndex = 16;
			// 
			// chkSpisningTvungen
			// 
			this.chkSpisningTvungen.AutoSize = true;
			this.chkSpisningTvungen.Enabled = false;
			this.chkSpisningTvungen.Location = new System.Drawing.Point(173, 310);
			this.chkSpisningTvungen.Name = "chkSpisningTvungen";
			this.chkSpisningTvungen.Size = new System.Drawing.Size(15, 14);
			this.chkSpisningTvungen.TabIndex = 19;
			this.chkSpisningTvungen.UseVisualStyleBackColor = true;
			// 
			// chkSpisning
			// 
			this.chkSpisning.AutoSize = true;
			this.chkSpisning.Location = new System.Drawing.Point(99, 310);
			this.chkSpisning.Name = "chkSpisning";
			this.chkSpisning.Size = new System.Drawing.Size(15, 14);
			this.chkSpisning.TabIndex = 18;
			this.chkSpisning.UseVisualStyleBackColor = true;
			this.chkSpisning.CheckedChanged += new System.EventHandler(this.chkSpisning_CheckedChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 310);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(50, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Spisning:";
			// 
			// btnOpret
			// 
			this.btnOpret.Location = new System.Drawing.Point(12, 336);
			this.btnOpret.Name = "btnOpret";
			this.btnOpret.Size = new System.Drawing.Size(113, 23);
			this.btnOpret.TabIndex = 20;
			this.btnOpret.Text = "Opret";
			this.btnOpret.UseVisualStyleBackColor = true;
			this.btnOpret.Click += new System.EventHandler(this.btnOpret_Click);
			// 
			// btnAnnuller
			// 
			this.btnAnnuller.Location = new System.Drawing.Point(159, 336);
			this.btnAnnuller.Name = "btnAnnuller";
			this.btnAnnuller.Size = new System.Drawing.Size(127, 23);
			this.btnAnnuller.TabIndex = 21;
			this.btnAnnuller.Text = "Annuller";
			this.btnAnnuller.UseVisualStyleBackColor = true;
			// 
			// FrmOpstartScenarie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 371);
			this.Controls.Add(this.btnAnnuller);
			this.Controls.Add(this.btnOpret);
			this.Controls.Add(this.chkSpisningTvungen);
			this.Controls.Add(this.chkSpisning);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtAntalDage);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.chkOvernatningTvungen);
			this.Controls.Add(this.chkOvernatning);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtBeskrivelse);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPris);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSted);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtpTid);
			this.Controls.Add(this.txtNavn);
			this.Controls.Add(this.label1);
			this.Name = "FrmOpstartScenarie";
			this.Text = "Opstart scenarie";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.DateTimePicker dtpTid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSted;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox txtPris;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtBeskrivelse;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkOvernatning;
		private System.Windows.Forms.CheckBox chkOvernatningTvungen;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.MaskedTextBox txtAntalDage;
		private System.Windows.Forms.CheckBox chkSpisningTvungen;
		private System.Windows.Forms.CheckBox chkSpisning;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnOpret;
		private System.Windows.Forms.Button btnAnnuller;
	}
}