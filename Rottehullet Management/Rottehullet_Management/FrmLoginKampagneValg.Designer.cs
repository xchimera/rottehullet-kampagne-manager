namespace Rottehullet_Management
{
	partial class FrmLoginKampagneValg
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
            this.lstKampagner = new System.Windows.Forms.ListView();
            this.KampagneID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVælgKampagne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstKampagner
            // 
            this.lstKampagner.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.KampagneID,
            this.Navn});
            this.lstKampagner.FullRowSelect = true;
            this.lstKampagner.Location = new System.Drawing.Point(12, 12);
            this.lstKampagner.Name = "lstKampagner";
            this.lstKampagner.Size = new System.Drawing.Size(283, 135);
            this.lstKampagner.TabIndex = 0;
            this.lstKampagner.UseCompatibleStateImageBehavior = false;
            this.lstKampagner.View = System.Windows.Forms.View.Details;
            // 
            // KampagneID
            // 
            this.KampagneID.Text = "";
            this.KampagneID.Width = 0;
            // 
            // Navn
            // 
            this.Navn.Text = "Navn";
            this.Navn.Width = 278;
            // 
            // btnVælgKampagne
            // 
            this.btnVælgKampagne.Location = new System.Drawing.Point(105, 153);
            this.btnVælgKampagne.Name = "btnVælgKampagne";
            this.btnVælgKampagne.Size = new System.Drawing.Size(93, 23);
            this.btnVælgKampagne.TabIndex = 1;
            this.btnVælgKampagne.Text = "Vælg kampagne";
            this.btnVælgKampagne.UseVisualStyleBackColor = true;
            this.btnVælgKampagne.Click += new System.EventHandler(this.btnVælgKampagne_Click);
            // 
            // FrmLoginKampagneValg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 188);
            this.Controls.Add(this.btnVælgKampagne);
            this.Controls.Add(this.lstKampagner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLoginKampagneValg";
            this.Text = "Kampagner";
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ListView lstKampagner;
        private System.Windows.Forms.ColumnHeader KampagneID;
        private System.Windows.Forms.ColumnHeader Navn;
        private System.Windows.Forms.Button btnVælgKampagne;


    }
}