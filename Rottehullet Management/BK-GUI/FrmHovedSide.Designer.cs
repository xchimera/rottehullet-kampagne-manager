namespace BK_GUI
{
    partial class FrmHovedSide
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
            this.lstkaraktere = new System.Windows.Forms.ListView();
            this.btnNyKarakter = new System.Windows.Forms.Button();
            this.btnNyOpdaterDisabled = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSkiftKampagne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstkaraktere
            // 
            this.lstkaraktere.Location = new System.Drawing.Point(41, 27);
            this.lstkaraktere.Name = "lstkaraktere";
            this.lstkaraktere.Size = new System.Drawing.Size(192, 163);
            this.lstkaraktere.TabIndex = 0;
            this.lstkaraktere.UseCompatibleStateImageBehavior = false;
            // 
            // btnNyKarakter
            // 
            this.btnNyKarakter.Location = new System.Drawing.Point(53, 214);
            this.btnNyKarakter.Name = "btnNyKarakter";
            this.btnNyKarakter.Size = new System.Drawing.Size(153, 23);
            this.btnNyKarakter.TabIndex = 1;
            this.btnNyKarakter.Text = "Ny Karakter";
            this.btnNyKarakter.UseVisualStyleBackColor = true;
            // 
            // btnNyOpdaterDisabled
            // 
            this.btnNyOpdaterDisabled.Location = new System.Drawing.Point(53, 259);
            this.btnNyOpdaterDisabled.Name = "btnNyOpdaterDisabled";
            this.btnNyOpdaterDisabled.Size = new System.Drawing.Size(153, 23);
            this.btnNyOpdaterDisabled.TabIndex = 2;
            this.btnNyOpdaterDisabled.Text = "Ny/Opdater/Disabled";
            this.btnNyOpdaterDisabled.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 304);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Tilmeld Karakter til Scenarie";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnSkiftKampagne
            // 
            this.btnSkiftKampagne.Location = new System.Drawing.Point(53, 403);
            this.btnSkiftKampagne.Name = "btnSkiftKampagne";
            this.btnSkiftKampagne.Size = new System.Drawing.Size(153, 23);
            this.btnSkiftKampagne.TabIndex = 4;
            this.btnSkiftKampagne.Text = "Skift Kampagne";
            this.btnSkiftKampagne.UseVisualStyleBackColor = true;
            this.btnSkiftKampagne.Click += new System.EventHandler(this.btnSkiftKampagne_Click);
            // 
            // FrmHovedSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 438);
            this.Controls.Add(this.btnSkiftKampagne);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnNyOpdaterDisabled);
            this.Controls.Add(this.btnNyKarakter);
            this.Controls.Add(this.lstkaraktere);
            this.Name = "FrmHovedSide";
            this.Text = "HovedSide";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstkaraktere;
        private System.Windows.Forms.Button btnNyKarakter;
        private System.Windows.Forms.Button btnNyOpdaterDisabled;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSkiftKampagne;
    }
}