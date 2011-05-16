namespace BK_GUI
{
	partial class FrmRetBruger
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
			this.btnAnnuller = new System.Windows.Forms.Button();
			this.txtAndet = new System.Windows.Forms.TextBox();
			this.txtAllergi = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.chkVeganer = new System.Windows.Forms.CheckBox();
			this.chkVegetar = new System.Windows.Forms.CheckBox();
			this.dtpFødselsdag = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNød_tlf = new System.Windows.Forms.TextBox();
			this.txtTlf = new System.Windows.Forms.TextBox();
			this.txtNavn = new System.Windows.Forms.TextBox();
			this.btnTilføjBruger = new System.Windows.Forms.Button();
			this.btnKodeord = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAnnuller
			// 
			this.btnAnnuller.Location = new System.Drawing.Point(200, 312);
			this.btnAnnuller.Name = "btnAnnuller";
			this.btnAnnuller.Size = new System.Drawing.Size(61, 23);
			this.btnAnnuller.TabIndex = 33;
			this.btnAnnuller.Text = "Annuller";
			this.btnAnnuller.UseVisualStyleBackColor = true;
			this.btnAnnuller.Click += new System.EventHandler(this.btnAnnuller_Click);
			// 
			// txtAndet
			// 
			this.txtAndet.Location = new System.Drawing.Point(88, 214);
			this.txtAndet.Multiline = true;
			this.txtAndet.Name = "txtAndet";
			this.txtAndet.Size = new System.Drawing.Size(173, 93);
			this.txtAndet.TabIndex = 32;
			// 
			// txtAllergi
			// 
			this.txtAllergi.Location = new System.Drawing.Point(88, 153);
			this.txtAllergi.Multiline = true;
			this.txtAllergi.Name = "txtAllergi";
			this.txtAllergi.Size = new System.Drawing.Size(173, 55);
			this.txtAllergi.TabIndex = 31;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 214);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 29;
			this.label8.Text = "Andet";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 153);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 13);
			this.label7.TabIndex = 30;
			this.label7.Text = "Allergier";
			// 
			// chkVeganer
			// 
			this.chkVeganer.AutoSize = true;
			this.chkVeganer.Location = new System.Drawing.Point(123, 130);
			this.chkVeganer.Name = "chkVeganer";
			this.chkVeganer.Size = new System.Drawing.Size(66, 17);
			this.chkVeganer.TabIndex = 27;
			this.chkVeganer.Text = "Veganer";
			this.chkVeganer.UseVisualStyleBackColor = true;
			// 
			// chkVegetar
			// 
			this.chkVegetar.AutoSize = true;
			this.chkVegetar.Location = new System.Drawing.Point(36, 130);
			this.chkVegetar.Name = "chkVegetar";
			this.chkVegetar.Size = new System.Drawing.Size(63, 17);
			this.chkVegetar.TabIndex = 26;
			this.chkVegetar.Text = "Vegetar";
			this.chkVegetar.UseVisualStyleBackColor = true;
			// 
			// dtpFødselsdag
			// 
			this.dtpFødselsdag.Location = new System.Drawing.Point(105, 43);
			this.dtpFødselsdag.Name = "dtpFødselsdag";
			this.dtpFødselsdag.Size = new System.Drawing.Size(156, 20);
			this.dtpFødselsdag.TabIndex = 23;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 26);
			this.label6.TabIndex = 18;
			this.label6.Text = "Telefonnr til \r\nkontaktperson";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Telefonnr:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 13);
			this.label5.TabIndex = 20;
			this.label5.Text = "Fødselsdagsdato";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Navn";
			// 
			// txtNød_tlf
			// 
			this.txtNød_tlf.Location = new System.Drawing.Point(88, 104);
			this.txtNød_tlf.Name = "txtNød_tlf";
			this.txtNød_tlf.Size = new System.Drawing.Size(173, 20);
			this.txtNød_tlf.TabIndex = 25;
			// 
			// txtTlf
			// 
			this.txtTlf.Location = new System.Drawing.Point(88, 69);
			this.txtTlf.Name = "txtTlf";
			this.txtTlf.Size = new System.Drawing.Size(173, 20);
			this.txtTlf.TabIndex = 24;
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(88, 17);
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.Size = new System.Drawing.Size(173, 20);
			this.txtNavn.TabIndex = 21;
			// 
			// btnTilføjBruger
			// 
			this.btnTilføjBruger.Location = new System.Drawing.Point(13, 312);
			this.btnTilføjBruger.Name = "btnTilføjBruger";
			this.btnTilføjBruger.Size = new System.Drawing.Size(96, 23);
			this.btnTilføjBruger.TabIndex = 28;
			this.btnTilføjBruger.Text = "Ret Informationer";
			this.btnTilføjBruger.UseVisualStyleBackColor = true;
			this.btnTilføjBruger.Click += new System.EventHandler(this.btnTilføjBruger_Click);
			// 
			// btnKodeord
			// 
			this.btnKodeord.Location = new System.Drawing.Point(115, 313);
			this.btnKodeord.Name = "btnKodeord";
			this.btnKodeord.Size = new System.Drawing.Size(79, 23);
			this.btnKodeord.TabIndex = 34;
			this.btnKodeord.Text = "Skift Kodeord";
			this.btnKodeord.UseVisualStyleBackColor = true;
			this.btnKodeord.Click += new System.EventHandler(this.btnKodeord_Click);
			// 
			// FrmRetBruger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(273, 347);
			this.Controls.Add(this.btnKodeord);
			this.Controls.Add(this.btnAnnuller);
			this.Controls.Add(this.txtAndet);
			this.Controls.Add(this.txtAllergi);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.chkVeganer);
			this.Controls.Add(this.chkVegetar);
			this.Controls.Add(this.dtpFødselsdag);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNød_tlf);
			this.Controls.Add(this.txtTlf);
			this.Controls.Add(this.txtNavn);
			this.Controls.Add(this.btnTilføjBruger);
			this.Name = "FrmRetBruger";
			this.Text = "RetBruger";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAnnuller;
		private System.Windows.Forms.TextBox txtAndet;
		private System.Windows.Forms.TextBox txtAllergi;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkVeganer;
		private System.Windows.Forms.CheckBox chkVegetar;
		private System.Windows.Forms.DateTimePicker dtpFødselsdag;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNød_tlf;
		private System.Windows.Forms.TextBox txtTlf;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.Button btnTilføjBruger;
		private System.Windows.Forms.Button btnKodeord;
	}
}