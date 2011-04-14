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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brugernavn";
            // 
            // txtBrugernavn
            // 
            this.txtBrugernavn.Location = new System.Drawing.Point(107, 102);
            this.txtBrugernavn.Name = "txtBrugernavn";
            this.txtBrugernavn.Size = new System.Drawing.Size(100, 20);
            this.txtBrugernavn.TabIndex = 1;
            // 
            // txtKodeord
            // 
            this.txtKodeord.Location = new System.Drawing.Point(107, 128);
            this.txtKodeord.Name = "txtKodeord";
            this.txtKodeord.PasswordChar = '*';
            this.txtKodeord.Size = new System.Drawing.Size(100, 20);
            this.txtKodeord.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kodeord";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(107, 161);
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
            this.lblOpretBruger.Location = new System.Drawing.Point(68, 189);
            this.lblOpretBruger.Name = "lblOpretBruger";
            this.lblOpretBruger.Size = new System.Drawing.Size(154, 13);
            this.lblOpretBruger.TabIndex = 5;
            this.lblOpretBruger.Text = "Har du ikke en bruger? Klik her";
            this.lblOpretBruger.Click += new System.EventHandler(this.lblOpretBruger_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 211);
            this.Controls.Add(this.lblOpretBruger);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKodeord);
            this.Controls.Add(this.txtBrugernavn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "Login";
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
    }
}