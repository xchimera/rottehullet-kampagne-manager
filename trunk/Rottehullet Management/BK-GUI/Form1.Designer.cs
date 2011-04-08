namespace BK_GUI
{
    partial class BK_Klient
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
            this.SuspendLayout();
            // 
            // btnTilføjBruger
            // 
            this.btnTilføjBruger.Location = new System.Drawing.Point(260, 208);
            this.btnTilføjBruger.Name = "btnTilføjBruger";
            this.btnTilføjBruger.Size = new System.Drawing.Size(75, 23);
            this.btnTilføjBruger.TabIndex = 9;
            this.btnTilføjBruger.Text = "TilføjBruger";
            this.btnTilføjBruger.UseVisualStyleBackColor = true;
            this.btnTilføjBruger.Click += new System.EventHandler(this.btnTilføjBruger_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(127, 41);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "eMail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Navn";
            // 
            // txtNavn
            // 
            this.txtNavn.Location = new System.Drawing.Point(127, 93);
            this.txtNavn.Name = "txtNavn";
            this.txtNavn.Size = new System.Drawing.Size(100, 20);
            this.txtNavn.TabIndex = 3;
            // 
            // txtTlf
            // 
            this.txtTlf.Location = new System.Drawing.Point(127, 160);
            this.txtTlf.Name = "txtTlf";
            this.txtTlf.Size = new System.Drawing.Size(100, 20);
            this.txtTlf.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tlf";
            // 
            // txtKodeord
            // 
            this.txtKodeord.Location = new System.Drawing.Point(127, 67);
            this.txtKodeord.Name = "txtKodeord";
            this.txtKodeord.Size = new System.Drawing.Size(100, 20);
            this.txtKodeord.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kodeord";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fødselsdagsdato";
            // 
            // dtpFødselsdag
            // 
            this.dtpFødselsdag.Location = new System.Drawing.Point(127, 127);
            this.dtpFødselsdag.Name = "dtpFødselsdag";
            this.dtpFødselsdag.Size = new System.Drawing.Size(129, 20);
            this.dtpFødselsdag.TabIndex = 4;
            // 
            // txtNød_tlf
            // 
            this.txtNød_tlf.Location = new System.Drawing.Point(127, 186);
            this.txtNød_tlf.Name = "txtNød_tlf";
            this.txtNød_tlf.Size = new System.Drawing.Size(100, 20);
            this.txtNød_tlf.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nød_Tlf";
            // 
            // chkVegetar
            // 
            this.chkVegetar.AutoSize = true;
            this.chkVegetar.Location = new System.Drawing.Point(74, 212);
            this.chkVegetar.Name = "chkVegetar";
            this.chkVegetar.Size = new System.Drawing.Size(63, 17);
            this.chkVegetar.TabIndex = 7;
            this.chkVegetar.Text = "Vegetar";
            this.chkVegetar.UseVisualStyleBackColor = true;
            // 
            // chkVeganer
            // 
            this.chkVeganer.AutoSize = true;
            this.chkVeganer.Location = new System.Drawing.Point(170, 212);
            this.chkVeganer.Name = "chkVeganer";
            this.chkVeganer.Size = new System.Drawing.Size(66, 17);
            this.chkVeganer.TabIndex = 8;
            this.chkVeganer.Text = "Veganer";
            this.chkVeganer.UseVisualStyleBackColor = true;
            // 
            // BK_Klient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 335);
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
            this.Name = "BK_Klient";
            this.Text = "BrugerKlient";
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
    }
}

