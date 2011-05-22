namespace Rottehullet_Management
{
	partial class FrmSkiftTopbruger
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
			this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Kampagne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.lstBrugere = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.brugerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstKampagner
			// 
			this.lstKampagner.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.Kampagne});
			this.lstKampagner.Location = new System.Drawing.Point(6, 36);
			this.lstKampagner.Name = "lstKampagner";
			this.lstKampagner.Size = new System.Drawing.Size(199, 358);
			this.lstKampagner.TabIndex = 0;
			this.lstKampagner.UseCompatibleStateImageBehavior = false;
			this.lstKampagner.View = System.Windows.Forms.View.Details;
			// 
			// id
			// 
			this.id.Text = "ID";
			this.id.Width = 0;
			// 
			// Kampagne
			// 
			this.Kampagne.Text = "Kampagne";
			this.Kampagne.Width = 195;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lstKampagner);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(211, 400);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Kampagne";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Vælg Kampagne:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.lstBrugere);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(229, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(211, 400);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Topbruger";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(52, 371);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(108, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Sæt som topbruger";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// lstBrugere
			// 
			this.lstBrugere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.brugerID,
            this.Navn});
			this.lstBrugere.Location = new System.Drawing.Point(6, 36);
			this.lstBrugere.Name = "lstBrugere";
			this.lstBrugere.Size = new System.Drawing.Size(199, 329);
			this.lstBrugere.TabIndex = 3;
			this.lstBrugere.UseCompatibleStateImageBehavior = false;
			this.lstBrugere.View = System.Windows.Forms.View.Details;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Vælg topbruger:";
			// 
			// brugerID
			// 
			this.brugerID.Text = "ID";
			this.brugerID.Width = 0;
			// 
			// Navn
			// 
			this.Navn.Text = "Navn";
			this.Navn.Width = 194;
			// 
			// FrmSkiftTopbruger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(452, 424);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "FrmSkiftTopbruger";
			this.Text = "Skift Topbruger";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstKampagner;
		private System.Windows.Forms.ColumnHeader id;
		private System.Windows.Forms.ColumnHeader Kampagne;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lstBrugere;
		private System.Windows.Forms.ColumnHeader brugerID;
		private System.Windows.Forms.ColumnHeader Navn;
	}
}