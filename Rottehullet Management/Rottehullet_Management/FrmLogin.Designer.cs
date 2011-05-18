namespace Rottehullet_Management
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
			this.txtBrugernavn = new System.Windows.Forms.TextBox();
			this.txtKodeord = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.chkHuskBrugernavn = new System.Windows.Forms.CheckBox();
			this.chkHuskAdgangskode = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtBrugernavn
			// 
			this.txtBrugernavn.Location = new System.Drawing.Point(116, 12);
			this.txtBrugernavn.Name = "txtBrugernavn";
			this.txtBrugernavn.Size = new System.Drawing.Size(100, 20);
			this.txtBrugernavn.TabIndex = 0;
			// 
			// txtKodeord
			// 
			this.txtKodeord.Location = new System.Drawing.Point(116, 39);
			this.txtKodeord.Name = "txtKodeord";
			this.txtKodeord.PasswordChar = '*';
			this.txtKodeord.Size = new System.Drawing.Size(100, 20);
			this.txtKodeord.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Brugernavn";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Adgangskode";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(101, 74);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 4;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// chkHuskBrugernavn
			// 
			this.chkHuskBrugernavn.AutoSize = true;
			this.chkHuskBrugernavn.Location = new System.Drawing.Point(85, 103);
			this.chkHuskBrugernavn.Name = "chkHuskBrugernavn";
			this.chkHuskBrugernavn.Size = new System.Drawing.Size(109, 17);
			this.chkHuskBrugernavn.TabIndex = 5;
			this.chkHuskBrugernavn.Text = "Husk Brugernavn";
			this.chkHuskBrugernavn.UseVisualStyleBackColor = true;
			this.chkHuskBrugernavn.CheckedChanged += new System.EventHandler(this.chkHuskBrugernavn_CheckedChanged);
			// 
			// chkHuskAdgangskode
			// 
			this.chkHuskAdgangskode.AutoSize = true;
			this.chkHuskAdgangskode.Enabled = false;
			this.chkHuskAdgangskode.Location = new System.Drawing.Point(85, 127);
			this.chkHuskAdgangskode.Name = "chkHuskAdgangskode";
			this.chkHuskAdgangskode.Size = new System.Drawing.Size(120, 17);
			this.chkHuskAdgangskode.TabIndex = 6;
			this.chkHuskAdgangskode.Text = "Husk Adgangskode";
			this.chkHuskAdgangskode.UseVisualStyleBackColor = true;
			this.chkHuskAdgangskode.CheckedChanged += new System.EventHandler(this.chkHuskAdgangskode_CheckedChanged);
			// 
			// FrmLogin
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 152);
			this.Controls.Add(this.chkHuskAdgangskode);
			this.Controls.Add(this.chkHuskBrugernavn);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtKodeord);
			this.Controls.Add(this.txtBrugernavn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrugernavn;
        private System.Windows.Forms.TextBox txtKodeord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.CheckBox chkHuskBrugernavn;
		private System.Windows.Forms.CheckBox chkHuskAdgangskode;
    }
}

