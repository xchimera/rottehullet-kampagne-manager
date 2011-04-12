namespace Rottehullet_Management
{
    partial class FrmOpretKampagne
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
            this.txtKampagneNavn = new System.Windows.Forms.TextBox();
            this.lstBrugere = new System.Windows.Forms.ListView();
            this.BrugerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSøgBruger = new System.Windows.Forms.TextBox();
            this.btnOpretKampagne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Navn";
            // 
            // txtKampagneNavn
            // 
            this.txtKampagneNavn.Location = new System.Drawing.Point(83, 17);
            this.txtKampagneNavn.Name = "txtKampagneNavn";
            this.txtKampagneNavn.Size = new System.Drawing.Size(100, 20);
            this.txtKampagneNavn.TabIndex = 3;
            // 
            // lstBrugere
            // 
            this.lstBrugere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BrugerID,
            this.Navn});
            this.lstBrugere.FullRowSelect = true;
            this.lstBrugere.Location = new System.Drawing.Point(16, 105);
            this.lstBrugere.Name = "lstBrugere";
            this.lstBrugere.Size = new System.Drawing.Size(168, 87);
            this.lstBrugere.TabIndex = 6;
            this.lstBrugere.UseCompatibleStateImageBehavior = false;
            this.lstBrugere.View = System.Windows.Forms.View.Details;
            // 
            // BrugerID
            // 
            this.BrugerID.Text = "";
            this.BrugerID.Width = 0;
            // 
            // Navn
            // 
            this.Navn.Text = "Navn";
            this.Navn.Width = 164;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vælg topbruger";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Søg";
            // 
            // txtSøgBruger
            // 
            this.txtSøgBruger.Location = new System.Drawing.Point(46, 79);
            this.txtSøgBruger.Name = "txtSøgBruger";
            this.txtSøgBruger.Size = new System.Drawing.Size(100, 20);
            this.txtSøgBruger.TabIndex = 9;
            this.txtSøgBruger.TextChanged += new System.EventHandler(this.txtSøgBruger_TextChanged);
            // 
            // btnOpretKampagne
            // 
            this.btnOpretKampagne.Location = new System.Drawing.Point(16, 226);
            this.btnOpretKampagne.Name = "btnOpretKampagne";
            this.btnOpretKampagne.Size = new System.Drawing.Size(94, 23);
            this.btnOpretKampagne.TabIndex = 10;
            this.btnOpretKampagne.Text = "Opret kampagne";
            this.btnOpretKampagne.UseVisualStyleBackColor = true;
            this.btnOpretKampagne.Click += new System.EventHandler(this.btnOpretKampagne_Click);
            // 
            // FrmOpretKampagne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 327);
            this.Controls.Add(this.btnOpretKampagne);
            this.Controls.Add(this.txtSøgBruger);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstBrugere);
            this.Controls.Add(this.txtKampagneNavn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmOpretKampagne";
            this.Text = "Opret_kampagne";
            this.Load += new System.EventHandler(this.Opret_kampagne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKampagneNavn;
        private System.Windows.Forms.ListView lstBrugere;
        private System.Windows.Forms.ColumnHeader Navn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSøgBruger;
        private System.Windows.Forms.ColumnHeader BrugerID;
        private System.Windows.Forms.Button btnOpretKampagne;
    }
}