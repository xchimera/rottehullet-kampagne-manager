namespace Rottehullet_Management
{
	partial class FrmTilføjAttribut
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
			this.txtNavn = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboType = new System.Windows.Forms.ComboBox();
			this.btnTilføj = new System.Windows.Forms.Button();
			this.lstValgmuligheder = new System.Windows.Forms.ListView();
			this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txtValgmulighed = new System.Windows.Forms.TextBox();
			this.btnTilføjValgmulighed = new System.Windows.Forms.Button();
			this.btnSletValgmulighed = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Navn:";
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(54, 10);
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.Size = new System.Drawing.Size(100, 20);
			this.txtNavn.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Type:";
			// 
			// cboType
			// 
			this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboType.FormattingEnabled = true;
			this.cboType.Items.AddRange(new object[] {
            "Tekstboks",
            "Flerlinjet tekstboks",
            "Multiple Choice"});
			this.cboType.Location = new System.Drawing.Point(52, 36);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(121, 21);
			this.cboType.TabIndex = 3;
			this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
			// 
			// btnTilføj
			// 
			this.btnTilføj.Location = new System.Drawing.Point(12, 259);
			this.btnTilføj.Name = "btnTilføj";
			this.btnTilføj.Size = new System.Drawing.Size(75, 23);
			this.btnTilføj.TabIndex = 4;
			this.btnTilføj.Text = "Tilføj";
			this.btnTilføj.UseVisualStyleBackColor = true;
			this.btnTilføj.Click += new System.EventHandler(this.btnTilføj_Click);
			// 
			// lstValgmuligheder
			// 
			this.lstValgmuligheder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Navn});
			this.lstValgmuligheder.FullRowSelect = true;
			this.lstValgmuligheder.Location = new System.Drawing.Point(12, 92);
			this.lstValgmuligheder.MultiSelect = false;
			this.lstValgmuligheder.Name = "lstValgmuligheder";
			this.lstValgmuligheder.Size = new System.Drawing.Size(201, 141);
			this.lstValgmuligheder.TabIndex = 5;
			this.lstValgmuligheder.UseCompatibleStateImageBehavior = false;
			this.lstValgmuligheder.View = System.Windows.Forms.View.Details;
			// 
			// Navn
			// 
			this.Navn.Text = "Navn";
			this.Navn.Width = 196;
			// 
			// txtValgmulighed
			// 
			this.txtValgmulighed.Location = new System.Drawing.Point(15, 63);
			this.txtValgmulighed.Name = "txtValgmulighed";
			this.txtValgmulighed.Size = new System.Drawing.Size(100, 20);
			this.txtValgmulighed.TabIndex = 6;
			// 
			// btnTilføjValgmulighed
			// 
			this.btnTilføjValgmulighed.Location = new System.Drawing.Point(121, 61);
			this.btnTilføjValgmulighed.Name = "btnTilføjValgmulighed";
			this.btnTilføjValgmulighed.Size = new System.Drawing.Size(109, 23);
			this.btnTilføjValgmulighed.TabIndex = 7;
			this.btnTilføjValgmulighed.Text = "Tilføj valgmulighed";
			this.btnTilføjValgmulighed.UseVisualStyleBackColor = true;
			this.btnTilføjValgmulighed.Click += new System.EventHandler(this.btnTilføjValgmulighed_Click);
			// 
			// btnSletValgmulighed
			// 
			this.btnSletValgmulighed.Location = new System.Drawing.Point(227, 125);
			this.btnSletValgmulighed.Name = "btnSletValgmulighed";
			this.btnSletValgmulighed.Size = new System.Drawing.Size(108, 23);
			this.btnSletValgmulighed.TabIndex = 8;
			this.btnSletValgmulighed.Text = "Slet valgmulighed";
			this.btnSletValgmulighed.UseVisualStyleBackColor = true;
			this.btnSletValgmulighed.Click += new System.EventHandler(this.btnSletValgmulighed_Click);
			// 
			// FrmTilføjAttribut
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 294);
			this.Controls.Add(this.btnSletValgmulighed);
			this.Controls.Add(this.btnTilføjValgmulighed);
			this.Controls.Add(this.txtValgmulighed);
			this.Controls.Add(this.lstValgmuligheder);
			this.Controls.Add(this.btnTilføj);
			this.Controls.Add(this.cboType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNavn);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmTilføjAttribut";
			this.Text = "Tilføj Attribut";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboType;
		private System.Windows.Forms.Button btnTilføj;
		private System.Windows.Forms.ListView lstValgmuligheder;
		private System.Windows.Forms.ColumnHeader Navn;
		private System.Windows.Forms.TextBox txtValgmulighed;
		private System.Windows.Forms.Button btnTilføjValgmulighed;
		private System.Windows.Forms.Button btnSletValgmulighed;
	}
}