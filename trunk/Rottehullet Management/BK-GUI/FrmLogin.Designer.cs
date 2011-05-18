namespace BK_GUI
{
    partial class FrmLogin
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
			this.txtBrugernavn = new System.Windows.Forms.TextBox();
			this.txtKodeord = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.lblOpretBruger = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.chkHuskBrugernavn = new System.Windows.Forms.CheckBox();
			this.chkHuskAdgangskode = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 211);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Brugernavn";
			// 
			// txtBrugernavn
			// 
			this.txtBrugernavn.Location = new System.Drawing.Point(142, 208);
			this.txtBrugernavn.Name = "txtBrugernavn";
			this.txtBrugernavn.Size = new System.Drawing.Size(100, 20);
			this.txtBrugernavn.TabIndex = 1;
			// 
			// txtKodeord
			// 
			this.txtKodeord.Location = new System.Drawing.Point(142, 234);
			this.txtKodeord.Name = "txtKodeord";
			this.txtKodeord.PasswordChar = '*';
			this.txtKodeord.Size = new System.Drawing.Size(100, 20);
			this.txtKodeord.TabIndex = 2;
			this.txtKodeord.TextChanged += new System.EventHandler(this.txtKodeord_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(56, 237);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Adgangskode";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(152, 260);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 4;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// lblOpretBruger
			// 
			this.lblOpretBruger.AutoSize = true;
			this.lblOpretBruger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOpretBruger.Location = new System.Drawing.Point(114, 328);
			this.lblOpretBruger.Name = "lblOpretBruger";
			this.lblOpretBruger.Size = new System.Drawing.Size(154, 13);
			this.lblOpretBruger.TabIndex = 5;
			this.lblOpretBruger.Text = "Har du ikke en bruger? Klik her";
			this.lblOpretBruger.Click += new System.EventHandler(this.lblOpretBruger_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::BK_GUI.Properties.Resources.RP_Management_LOGO;
			this.pictureBox1.Location = new System.Drawing.Point(9, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(348, 190);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// chkHuskBrugernavn
			// 
			this.chkHuskBrugernavn.AutoSize = true;
			this.chkHuskBrugernavn.Location = new System.Drawing.Point(139, 289);
			this.chkHuskBrugernavn.Name = "chkHuskBrugernavn";
			this.chkHuskBrugernavn.Size = new System.Drawing.Size(109, 17);
			this.chkHuskBrugernavn.TabIndex = 7;
			this.chkHuskBrugernavn.Text = "Husk Brugernavn";
			this.chkHuskBrugernavn.UseVisualStyleBackColor = true;
			this.chkHuskBrugernavn.CheckedChanged += new System.EventHandler(this.chkHuskBrugernavn_CheckedChanged);
			// 
			// chkHuskAdgangskode
			// 
			this.chkHuskAdgangskode.AutoSize = true;
			this.chkHuskAdgangskode.Enabled = false;
			this.chkHuskAdgangskode.Location = new System.Drawing.Point(139, 308);
			this.chkHuskAdgangskode.Name = "chkHuskAdgangskode";
			this.chkHuskAdgangskode.Size = new System.Drawing.Size(120, 17);
			this.chkHuskAdgangskode.TabIndex = 8;
			this.chkHuskAdgangskode.Text = "Husk Adgangskode";
			this.chkHuskAdgangskode.UseVisualStyleBackColor = true;
			this.chkHuskAdgangskode.CheckedChanged += new System.EventHandler(this.chkHuskAdgangskode_CheckedChanged);
			// 
			// FrmLogin
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(369, 350);
			this.Controls.Add(this.chkHuskAdgangskode);
			this.Controls.Add(this.chkHuskBrugernavn);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblOpretBruger);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtKodeord);
			this.Controls.Add(this.txtBrugernavn);
			this.Controls.Add(this.label1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmLogin";
			this.Text = "Login";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrugernavn;
        private System.Windows.Forms.TextBox txtKodeord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblOpretBruger;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.CheckBox chkHuskBrugernavn;
		private System.Windows.Forms.CheckBox chkHuskAdgangskode;
    }
}