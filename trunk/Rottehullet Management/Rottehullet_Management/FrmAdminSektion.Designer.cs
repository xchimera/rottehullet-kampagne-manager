namespace Rottehullet_Management
{
    partial class FrmAdminSektion
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
			this.btnOpretKampagne = new System.Windows.Forms.Button();
			this.btnAdminkode = new System.Windows.Forms.Button();
			this.btnSkiftTopbruger = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpretKampagne
			// 
			this.btnOpretKampagne.Location = new System.Drawing.Point(13, 13);
			this.btnOpretKampagne.Name = "btnOpretKampagne";
			this.btnOpretKampagne.Size = new System.Drawing.Size(259, 23);
			this.btnOpretKampagne.TabIndex = 0;
			this.btnOpretKampagne.Text = "Opret kampagne";
			this.btnOpretKampagne.UseVisualStyleBackColor = true;
			this.btnOpretKampagne.Click += new System.EventHandler(this.btnOpretKampagne_Click);
			// 
			// btnAdminkode
			// 
			this.btnAdminkode.Location = new System.Drawing.Point(12, 72);
			this.btnAdminkode.Name = "btnAdminkode";
			this.btnAdminkode.Size = new System.Drawing.Size(259, 23);
			this.btnAdminkode.TabIndex = 1;
			this.btnAdminkode.Text = "Skift Adminkodeord";
			this.btnAdminkode.UseVisualStyleBackColor = true;
			this.btnAdminkode.Click += new System.EventHandler(this.btnAdminkode_Click);
			// 
			// btnSkiftTopbruger
			// 
			this.btnSkiftTopbruger.Location = new System.Drawing.Point(13, 43);
			this.btnSkiftTopbruger.Name = "btnSkiftTopbruger";
			this.btnSkiftTopbruger.Size = new System.Drawing.Size(259, 23);
			this.btnSkiftTopbruger.TabIndex = 2;
			this.btnSkiftTopbruger.Text = "Skift topbruger på kampagne";
			this.btnSkiftTopbruger.UseVisualStyleBackColor = true;
			this.btnSkiftTopbruger.Click += new System.EventHandler(this.btnSkiftTopbruger_Click);
			// 
			// FrmAdminSektion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnSkiftTopbruger);
			this.Controls.Add(this.btnAdminkode);
			this.Controls.Add(this.btnOpretKampagne);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmAdminSektion";
			this.Text = "Administration";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpretKampagne;
		private System.Windows.Forms.Button btnAdminkode;
		private System.Windows.Forms.Button btnSkiftTopbruger;
    }
}