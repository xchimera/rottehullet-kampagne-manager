namespace Rottehullet_Management
{
	partial class FrmRetAttribut
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
			this.btnSletValgmulighed = new System.Windows.Forms.Button();
			this.btnTilføjValgmulighed = new System.Windows.Forms.Button();
			this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txtValgmulighed = new System.Windows.Forms.TextBox();
			this.lstValgmuligheder = new System.Windows.Forms.ListView();
			this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnRet = new System.Windows.Forms.Button();
			this.cboType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNavn = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRetValgmulighed = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSletValgmulighed
			// 
			this.btnSletValgmulighed.Location = new System.Drawing.Point(227, 126);
			this.btnSletValgmulighed.Name = "btnSletValgmulighed";
			this.btnSletValgmulighed.Size = new System.Drawing.Size(108, 23);
			this.btnSletValgmulighed.TabIndex = 17;
			this.btnSletValgmulighed.Text = "Slet valgmulighed";
			this.btnSletValgmulighed.UseVisualStyleBackColor = true;
			this.btnSletValgmulighed.Click += new System.EventHandler(this.btnSletValgmulighed_Click);
			// 
			// btnTilføjValgmulighed
			// 
			this.btnTilføjValgmulighed.Location = new System.Drawing.Point(121, 62);
			this.btnTilføjValgmulighed.Name = "btnTilføjValgmulighed";
			this.btnTilføjValgmulighed.Size = new System.Drawing.Size(109, 23);
			this.btnTilføjValgmulighed.TabIndex = 16;
			this.btnTilføjValgmulighed.Text = "Tilføj valgmulighed";
			this.btnTilføjValgmulighed.UseVisualStyleBackColor = true;
			this.btnTilføjValgmulighed.Click += new System.EventHandler(this.btnTilføjValgmulighed_Click);
			// 
			// Navn
			// 
			this.Navn.Text = "Navn";
			this.Navn.Width = 196;
			// 
			// txtValgmulighed
			// 
			this.txtValgmulighed.Location = new System.Drawing.Point(15, 64);
			this.txtValgmulighed.Name = "txtValgmulighed";
			this.txtValgmulighed.Size = new System.Drawing.Size(100, 20);
			this.txtValgmulighed.TabIndex = 15;
			// 
			// lstValgmuligheder
			// 
			this.lstValgmuligheder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Navn});
			this.lstValgmuligheder.Location = new System.Drawing.Point(12, 93);
			this.lstValgmuligheder.MultiSelect = false;
			this.lstValgmuligheder.Name = "lstValgmuligheder";
			this.lstValgmuligheder.Size = new System.Drawing.Size(201, 141);
			this.lstValgmuligheder.TabIndex = 14;
			this.lstValgmuligheder.UseCompatibleStateImageBehavior = false;
			this.lstValgmuligheder.View = System.Windows.Forms.View.Details;
			// 
			// Id
			// 
			this.Id.Text = "Id";
			this.Id.Width = 0;
			// 
			// btnRet
			// 
			this.btnRet.Location = new System.Drawing.Point(12, 260);
			this.btnRet.Name = "btnRet";
			this.btnRet.Size = new System.Drawing.Size(75, 23);
			this.btnRet.TabIndex = 13;
			this.btnRet.Text = "Ret";
			this.btnRet.UseVisualStyleBackColor = true;
			this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
			// 
			// cboType
			// 
			this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboType.FormattingEnabled = true;
			this.cboType.Items.AddRange(new object[] {
            "Tekstboks",
            "Flerlinjet tekstboks",
            "Multiple Choice"});
			this.cboType.Location = new System.Drawing.Point(52, 37);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(121, 21);
			this.cboType.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Type:";
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(54, 11);
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.Size = new System.Drawing.Size(100, 20);
			this.txtNavn.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Navn:";
			// 
			// btnRetValgmulighed
			// 
			this.btnRetValgmulighed.Location = new System.Drawing.Point(227, 97);
			this.btnRetValgmulighed.Name = "btnRetValgmulighed";
			this.btnRetValgmulighed.Size = new System.Drawing.Size(108, 23);
			this.btnRetValgmulighed.TabIndex = 18;
			this.btnRetValgmulighed.Text = "Ret Valgmulighed";
			this.btnRetValgmulighed.UseVisualStyleBackColor = true;
			this.btnRetValgmulighed.Click += new System.EventHandler(this.btnRetValgmulighed_Click);
			// 
			// FrmRetAttribut
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 322);
			this.Controls.Add(this.btnRetValgmulighed);
			this.Controls.Add(this.btnSletValgmulighed);
			this.Controls.Add(this.btnTilføjValgmulighed);
			this.Controls.Add(this.txtValgmulighed);
			this.Controls.Add(this.lstValgmuligheder);
			this.Controls.Add(this.btnRet);
			this.Controls.Add(this.cboType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNavn);
			this.Controls.Add(this.label1);
			this.Name = "FrmRetAttribut";
			this.Text = "FrmRetAttribut";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSletValgmulighed;
		private System.Windows.Forms.Button btnTilføjValgmulighed;
		private System.Windows.Forms.ColumnHeader Navn;
		private System.Windows.Forms.TextBox txtValgmulighed;
		private System.Windows.Forms.ListView lstValgmuligheder;
		private System.Windows.Forms.Button btnRet;
		private System.Windows.Forms.ComboBox cboType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader Id;
		private System.Windows.Forms.Button btnRetValgmulighed;

	}
}