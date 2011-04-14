namespace BK_GUI
{
    partial class FrmOpretBruger
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
            this.btnTilføjBruger = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNavn = new System.Windows.Forms.TextBox();
            this.txtTlf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKodeord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFødselsdag = new System.Windows.Forms.DateTimePicker();
            this.txtNød_tlf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkVegetar = new System.Windows.Forms.CheckBox();
            this.chkVeganer = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAllergi = new System.Windows.Forms.TextBox();
            this.txtAndet = new System.Windows.Forms.TextBox();
            this.btnAnnuller = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTilføjBruger
            // 
            this.btnTilføjBruger.Location = new System.Drawing.Point(36, 373);
            this.btnTilføjBruger.Name = "btnTilføjBruger";
            this.btnTilføjBruger.Size = new System.Drawing.Size(75, 23);
            this.btnTilføjBruger.TabIndex = 9;
            this.btnTilføjBruger.Text = "Opret Bruger";
            this.btnTilføjBruger.UseVisualStyleBackColor = true;
            this.btnTilføjBruger.Click += new System.EventHandler(this.btnTilføjBruger_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(88, 44);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(154, 20);
            this.txtMail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Navn";
            // 
            // txtNavn
            // 
            this.txtNavn.Location = new System.Drawing.Point(88, 15);
            this.txtNavn.Name = "txtNavn";
            this.txtNavn.Size = new System.Drawing.Size(154, 20);
            this.txtNavn.TabIndex = 3;
            // 
            // txtTlf
            // 
            this.txtTlf.Location = new System.Drawing.Point(88, 129);
            this.txtTlf.Name = "txtTlf";
            this.txtTlf.Size = new System.Drawing.Size(154, 20);
            this.txtTlf.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Telefonnr:";
            // 
            // txtKodeord
            // 
            this.txtKodeord.Location = new System.Drawing.Point(88, 74);
            this.txtKodeord.Name = "txtKodeord";
            this.txtKodeord.PasswordChar = '*';
            this.txtKodeord.Size = new System.Drawing.Size(154, 20);
            this.txtKodeord.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kodeord";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fødselsdagsdato";
            // 
            // dtpFødselsdag
            // 
            this.dtpFødselsdag.Location = new System.Drawing.Point(105, 103);
            this.dtpFødselsdag.Name = "dtpFødselsdag";
            this.dtpFødselsdag.Size = new System.Drawing.Size(137, 20);
            this.dtpFødselsdag.TabIndex = 4;
            // 
            // txtNød_tlf
            // 
            this.txtNød_tlf.Location = new System.Drawing.Point(88, 164);
            this.txtNød_tlf.Name = "txtNød_tlf";
            this.txtNød_tlf.Size = new System.Drawing.Size(154, 20);
            this.txtNød_tlf.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Telefonnr til \r\nkontaktperson";
            // 
            // chkVegetar
            // 
            this.chkVegetar.AutoSize = true;
            this.chkVegetar.Location = new System.Drawing.Point(36, 190);
            this.chkVegetar.Name = "chkVegetar";
            this.chkVegetar.Size = new System.Drawing.Size(63, 17);
            this.chkVegetar.TabIndex = 7;
            this.chkVegetar.Text = "Vegetar";
            this.chkVegetar.UseVisualStyleBackColor = true;
            // 
            // chkVeganer
            // 
            this.chkVeganer.AutoSize = true;
            this.chkVeganer.Location = new System.Drawing.Point(123, 190);
            this.chkVeganer.Name = "chkVeganer";
            this.chkVeganer.Size = new System.Drawing.Size(66, 17);
            this.chkVeganer.TabIndex = 8;
            this.chkVeganer.Text = "Veganer";
            this.chkVeganer.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Allergier";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Andet";
            // 
            // txtAllergi
            // 
            this.txtAllergi.Location = new System.Drawing.Point(88, 213);
            this.txtAllergi.Multiline = true;
            this.txtAllergi.Name = "txtAllergi";
            this.txtAllergi.Size = new System.Drawing.Size(154, 55);
            this.txtAllergi.TabIndex = 11;
            // 
            // txtAndet
            // 
            this.txtAndet.Location = new System.Drawing.Point(88, 274);
            this.txtAndet.Multiline = true;
            this.txtAndet.Name = "txtAndet";
            this.txtAndet.Size = new System.Drawing.Size(154, 93);
            this.txtAndet.TabIndex = 12;
            // 
            // btnAnnuller
            // 
            this.btnAnnuller.Location = new System.Drawing.Point(145, 373);
            this.btnAnnuller.Name = "btnAnnuller";
            this.btnAnnuller.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuller.TabIndex = 13;
            this.btnAnnuller.Text = "Annuller";
            this.btnAnnuller.UseVisualStyleBackColor = true;
            this.btnAnnuller.Click += new System.EventHandler(this.btnAnnuller_Click);
            // 
            // FrmOpretBruger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 407);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNød_tlf);
            this.Controls.Add(this.txtTlf);
            this.Controls.Add(this.txtKodeord);
            this.Controls.Add(this.txtNavn);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.btnTilføjBruger);
            this.Name = "FrmOpretBruger";
            this.Text = "Opret Bruger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTilføjBruger;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNavn;
        private System.Windows.Forms.TextBox txtTlf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKodeord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFødselsdag;
        private System.Windows.Forms.TextBox txtNød_tlf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkVegetar;
        private System.Windows.Forms.CheckBox chkVeganer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAllergi;
        private System.Windows.Forms.TextBox txtAndet;
        private System.Windows.Forms.Button btnAnnuller;
    }
}

