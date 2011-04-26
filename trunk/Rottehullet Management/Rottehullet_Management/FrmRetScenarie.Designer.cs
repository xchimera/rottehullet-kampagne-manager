namespace Rottehullet_Management
{
	partial class FrmRetScenarie
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
			this.txtAndetInfo = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btnAnnuller = new System.Windows.Forms.Button();
			this.btnRet = new System.Windows.Forms.Button();
			this.chkSpisningTvungen = new System.Windows.Forms.CheckBox();
			this.chkSpisning = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtAntalDage = new System.Windows.Forms.MaskedTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.chkOvernatningTvungen = new System.Windows.Forms.CheckBox();
			this.chkOvernatning = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtBeskrivelse = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPris = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSted = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpTid = new System.Windows.Forms.DateTimePicker();
			this.txtNavn = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtAndetInfo
			// 
			this.txtAndetInfo.Location = new System.Drawing.Point(13, 347);
			this.txtAndetInfo.MaxLength = 4000;
			this.txtAndetInfo.Multiline = true;
			this.txtAndetInfo.Name = "txtAndetInfo";
			this.txtAndetInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAndetInfo.Size = new System.Drawing.Size(271, 128);
			this.txtAndetInfo.TabIndex = 39;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(10, 330);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(58, 13);
			this.label11.TabIndex = 46;
			this.label11.Text = "Andet info:";
			// 
			// btnAnnuller
			// 
			this.btnAnnuller.Location = new System.Drawing.Point(157, 481);
			this.btnAnnuller.Name = "btnAnnuller";
			this.btnAnnuller.Size = new System.Drawing.Size(127, 23);
			this.btnAnnuller.TabIndex = 41;
			this.btnAnnuller.Text = "Annuller";
			this.btnAnnuller.UseVisualStyleBackColor = true;
			this.btnAnnuller.Click += new System.EventHandler(this.btnAnnuller_Click);
			// 
			// btnRet
			// 
			this.btnRet.Location = new System.Drawing.Point(10, 481);
			this.btnRet.Name = "btnRet";
			this.btnRet.Size = new System.Drawing.Size(113, 23);
			this.btnRet.TabIndex = 40;
			this.btnRet.Text = "Ret";
			this.btnRet.UseVisualStyleBackColor = true;
			this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
			// 
			// chkSpisningTvungen
			// 
			this.chkSpisningTvungen.AutoSize = true;
			this.chkSpisningTvungen.Enabled = false;
			this.chkSpisningTvungen.Location = new System.Drawing.Point(171, 309);
			this.chkSpisningTvungen.Name = "chkSpisningTvungen";
			this.chkSpisningTvungen.Size = new System.Drawing.Size(15, 14);
			this.chkSpisningTvungen.TabIndex = 38;
			this.chkSpisningTvungen.UseVisualStyleBackColor = true;
			// 
			// chkSpisning
			// 
			this.chkSpisning.AutoSize = true;
			this.chkSpisning.Location = new System.Drawing.Point(97, 309);
			this.chkSpisning.Name = "chkSpisning";
			this.chkSpisning.Size = new System.Drawing.Size(15, 14);
			this.chkSpisning.TabIndex = 36;
			this.chkSpisning.UseVisualStyleBackColor = true;
			this.chkSpisning.CheckedChanged += new System.EventHandler(this.chkSpisning_CheckedChanged);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 309);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(50, 13);
			this.label10.TabIndex = 45;
			this.label10.Text = "Spisning:";
			// 
			// txtAntalDage
			// 
			this.txtAntalDage.Enabled = false;
			this.txtAntalDage.Location = new System.Drawing.Point(230, 283);
			this.txtAntalDage.Mask = "00";
			this.txtAntalDage.Name = "txtAntalDage";
			this.txtAntalDage.Size = new System.Drawing.Size(28, 20);
			this.txtAntalDage.TabIndex = 34;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(227, 262);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 44;
			this.label9.Text = "Antal";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(154, 262);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 43;
			this.label8.Text = "Tvungen";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(85, 262);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 42;
			this.label7.Text = "Tilvalg";
			// 
			// chkOvernatningTvungen
			// 
			this.chkOvernatningTvungen.AutoSize = true;
			this.chkOvernatningTvungen.Enabled = false;
			this.chkOvernatningTvungen.Location = new System.Drawing.Point(171, 286);
			this.chkOvernatningTvungen.Name = "chkOvernatningTvungen";
			this.chkOvernatningTvungen.Size = new System.Drawing.Size(15, 14);
			this.chkOvernatningTvungen.TabIndex = 33;
			this.chkOvernatningTvungen.UseVisualStyleBackColor = true;
			// 
			// chkOvernatning
			// 
			this.chkOvernatning.AutoSize = true;
			this.chkOvernatning.Location = new System.Drawing.Point(97, 286);
			this.chkOvernatning.Name = "chkOvernatning";
			this.chkOvernatning.Size = new System.Drawing.Size(15, 14);
			this.chkOvernatning.TabIndex = 31;
			this.chkOvernatning.UseVisualStyleBackColor = true;
			this.chkOvernatning.CheckedChanged += new System.EventHandler(this.chkOvernatning_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 286);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 13);
			this.label6.TabIndex = 37;
			this.label6.Text = "Overnatning:";
			// 
			// txtBeskrivelse
			// 
			this.txtBeskrivelse.Location = new System.Drawing.Point(10, 108);
			this.txtBeskrivelse.MaxLength = 4000;
			this.txtBeskrivelse.Multiline = true;
			this.txtBeskrivelse.Name = "txtBeskrivelse";
			this.txtBeskrivelse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBeskrivelse.Size = new System.Drawing.Size(274, 147);
			this.txtBeskrivelse.TabIndex = 30;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 91);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 35;
			this.label5.Text = "Beskrivelse:";
			// 
			// txtPris
			// 
			this.txtPris.Location = new System.Drawing.Point(201, 64);
			this.txtPris.Mask = "00000.00";
			this.txtPris.Name = "txtPris";
			this.txtPris.Size = new System.Drawing.Size(83, 20);
			this.txtPris.TabIndex = 28;
			this.txtPris.Text = "0000000";
			this.txtPris.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 13);
			this.label4.TabIndex = 32;
			this.label4.Text = "Pris:";
			// 
			// txtSted
			// 
			this.txtSted.Location = new System.Drawing.Point(84, 64);
			this.txtSted.MaxLength = 50;
			this.txtSted.Name = "txtSted";
			this.txtSted.Size = new System.Drawing.Size(78, 20);
			this.txtSted.TabIndex = 26;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Sted:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Tidspunkt:";
			// 
			// dtpTid
			// 
			this.dtpTid.CustomFormat = "dd-MM-yyyy                     kl. HH:mm";
			this.dtpTid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTid.Location = new System.Drawing.Point(84, 37);
			this.dtpTid.Name = "dtpTid";
			this.dtpTid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dtpTid.ShowUpDown = true;
			this.dtpTid.Size = new System.Drawing.Size(200, 20);
			this.dtpTid.TabIndex = 25;
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(84, 11);
			this.txtNavn.MaxLength = 50;
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.Size = new System.Drawing.Size(200, 20);
			this.txtNavn.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Navn:";
			// 
			// FrmRetScenarie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 513);
			this.Controls.Add(this.txtAndetInfo);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btnAnnuller);
			this.Controls.Add(this.btnRet);
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
			this.Name = "FrmRetScenarie";
			this.Text = "Ret scenarie";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtAndetInfo;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnAnnuller;
		private System.Windows.Forms.Button btnRet;
		private System.Windows.Forms.CheckBox chkSpisningTvungen;
		private System.Windows.Forms.CheckBox chkSpisning;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.MaskedTextBox txtAntalDage;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkOvernatningTvungen;
		private System.Windows.Forms.CheckBox chkOvernatning;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtBeskrivelse;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.MaskedTextBox txtPris;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSted;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpTid;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.Label label1;
	}
}