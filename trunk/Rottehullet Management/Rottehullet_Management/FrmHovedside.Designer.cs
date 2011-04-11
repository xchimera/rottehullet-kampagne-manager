namespace Rottehullet_Management
{
    partial class FrmHovedside
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBeskrivelse = new System.Windows.Forms.TextBox();
            this.btnRedigerNavn = new System.Windows.Forms.Button();
            this.btnRedigerHjemmeside = new System.Windows.Forms.Button();
            this.btnRedigerBeskrivelse = new System.Windows.Forms.Button();
            this.txtNavn = new System.Windows.Forms.TextBox();
            this.txtHjemmeside = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Navn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hjemmeside";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Beskrivelse";
            // 
            // txtBeskrivelse
            // 
            this.txtBeskrivelse.Enabled = false;
            this.txtBeskrivelse.Location = new System.Drawing.Point(16, 114);
            this.txtBeskrivelse.Multiline = true;
            this.txtBeskrivelse.Name = "txtBeskrivelse";
            this.txtBeskrivelse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBeskrivelse.Size = new System.Drawing.Size(175, 145);
            this.txtBeskrivelse.TabIndex = 5;
            // 
            // btnRedigerNavn
            // 
            this.btnRedigerNavn.Location = new System.Drawing.Point(184, 15);
            this.btnRedigerNavn.Name = "btnRedigerNavn";
            this.btnRedigerNavn.Size = new System.Drawing.Size(21, 23);
            this.btnRedigerNavn.TabIndex = 6;
            this.btnRedigerNavn.UseVisualStyleBackColor = true;
            this.btnRedigerNavn.Click += new System.EventHandler(this.btnRedigerNavn_Click);
            // 
            // btnRedigerHjemmeside
            // 
            this.btnRedigerHjemmeside.Location = new System.Drawing.Point(184, 46);
            this.btnRedigerHjemmeside.Name = "btnRedigerHjemmeside";
            this.btnRedigerHjemmeside.Size = new System.Drawing.Size(21, 23);
            this.btnRedigerHjemmeside.TabIndex = 7;
            this.btnRedigerHjemmeside.UseVisualStyleBackColor = true;
            this.btnRedigerHjemmeside.Click += new System.EventHandler(this.btnRedigerHjemmeside_Click);
            // 
            // btnRedigerBeskrivelse
            // 
            this.btnRedigerBeskrivelse.Location = new System.Drawing.Point(79, 83);
            this.btnRedigerBeskrivelse.Name = "btnRedigerBeskrivelse";
            this.btnRedigerBeskrivelse.Size = new System.Drawing.Size(21, 23);
            this.btnRedigerBeskrivelse.TabIndex = 8;
            this.btnRedigerBeskrivelse.UseVisualStyleBackColor = true;
            this.btnRedigerBeskrivelse.Click += new System.EventHandler(this.btnRedigerBeskrivelse_Click);
            // 
            // txtNavn
            // 
            this.txtNavn.Enabled = false;
            this.txtNavn.Location = new System.Drawing.Point(79, 15);
            this.txtNavn.Name = "txtNavn";
            this.txtNavn.Size = new System.Drawing.Size(100, 20);
            this.txtNavn.TabIndex = 9;
            // 
            // txtHjemmeside
            // 
            this.txtHjemmeside.Enabled = false;
            this.txtHjemmeside.Location = new System.Drawing.Point(79, 49);
            this.txtHjemmeside.Name = "txtHjemmeside";
            this.txtHjemmeside.Size = new System.Drawing.Size(100, 20);
            this.txtHjemmeside.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(79, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Skift kampagne";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // FrmHovedside
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 315);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtHjemmeside);
            this.Controls.Add(this.txtNavn);
            this.Controls.Add(this.btnRedigerBeskrivelse);
            this.Controls.Add(this.btnRedigerHjemmeside);
            this.Controls.Add(this.btnRedigerNavn);
            this.Controls.Add(this.txtBeskrivelse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmHovedside";
            this.Text = "Kampagne Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBeskrivelse;
        private System.Windows.Forms.Button btnRedigerNavn;
        private System.Windows.Forms.Button btnRedigerHjemmeside;
        private System.Windows.Forms.Button btnRedigerBeskrivelse;
        private System.Windows.Forms.TextBox txtNavn;
        private System.Windows.Forms.TextBox txtHjemmeside;
        private System.Windows.Forms.Button btnOk;
    }
}