namespace Rottehullet_Management
{
	partial class FrmAttributter
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
            this.lstAttributter = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTilføjAttribut = new System.Windows.Forms.Button();
            this.btnRetAttribut = new System.Windows.Forms.Button();
            this.btnSletAttribut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAttributter
            // 
            this.lstAttributter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Navn,
            this.Type});
            this.lstAttributter.FullRowSelect = true;
            this.lstAttributter.Location = new System.Drawing.Point(13, 12);
            this.lstAttributter.Name = "lstAttributter";
            this.lstAttributter.Size = new System.Drawing.Size(387, 345);
            this.lstAttributter.TabIndex = 0;
            this.lstAttributter.UseCompatibleStateImageBehavior = false;
            this.lstAttributter.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // Navn
            // 
            this.Navn.Text = "Navn";
            this.Navn.Width = 262;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 121;
            // 
            // btnTilføjAttribut
            // 
            this.btnTilføjAttribut.Location = new System.Drawing.Point(405, 23);
            this.btnTilføjAttribut.Name = "btnTilføjAttribut";
            this.btnTilføjAttribut.Size = new System.Drawing.Size(111, 23);
            this.btnTilføjAttribut.TabIndex = 1;
            this.btnTilføjAttribut.Text = "Tilføj Attribut";
            this.btnTilføjAttribut.UseVisualStyleBackColor = true;
            this.btnTilføjAttribut.Click += new System.EventHandler(this.btnTilføjAttribut_Click);
            // 
            // btnRetAttribut
            // 
            this.btnRetAttribut.Location = new System.Drawing.Point(405, 52);
            this.btnRetAttribut.Name = "btnRetAttribut";
            this.btnRetAttribut.Size = new System.Drawing.Size(111, 23);
            this.btnRetAttribut.TabIndex = 2;
            this.btnRetAttribut.Text = "Ret Attribut";
            this.btnRetAttribut.UseVisualStyleBackColor = true;
            this.btnRetAttribut.Click += new System.EventHandler(this.btnRetAttribut_Click);
            // 
            // btnSletAttribut
            // 
            this.btnSletAttribut.Location = new System.Drawing.Point(406, 82);
            this.btnSletAttribut.Name = "btnSletAttribut";
            this.btnSletAttribut.Size = new System.Drawing.Size(110, 23);
            this.btnSletAttribut.TabIndex = 3;
            this.btnSletAttribut.Text = "Slet Attribut";
            this.btnSletAttribut.UseVisualStyleBackColor = true;
            // 
            // FrmAttributter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 369);
            this.Controls.Add(this.btnSletAttribut);
            this.Controls.Add(this.btnRetAttribut);
            this.Controls.Add(this.btnTilføjAttribut);
            this.Controls.Add(this.lstAttributter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAttributter";
            this.Text = "Attributter";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstAttributter;
		private System.Windows.Forms.ColumnHeader Navn;
		private System.Windows.Forms.ColumnHeader Type;
		private System.Windows.Forms.Button btnTilføjAttribut;
		private System.Windows.Forms.Button btnRetAttribut;
		private System.Windows.Forms.Button btnSletAttribut;
		private System.Windows.Forms.ColumnHeader Id;
	}
}