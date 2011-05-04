namespace Rottehullet_Management
{
	partial class FrmKarakter
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
			this.txtAlder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTelefon = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtKontaktperson = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
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
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(95, 10);
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.ReadOnly = true;
			this.txtNavn.Size = new System.Drawing.Size(100, 20);
			this.txtNavn.TabIndex = 1;
			// 
			// txtAlder
			// 
			this.txtAlder.Location = new System.Drawing.Point(95, 36);
			this.txtAlder.Name = "txtAlder";
			this.txtAlder.ReadOnly = true;
			this.txtAlder.Size = new System.Drawing.Size(100, 20);
			this.txtAlder.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Alder";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(95, 62);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.ReadOnly = true;
			this.txtEmail.Size = new System.Drawing.Size(100, 20);
			this.txtEmail.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Email";
			// 
			// txtTelefon
			// 
			this.txtTelefon.Location = new System.Drawing.Point(95, 88);
			this.txtTelefon.Name = "txtTelefon";
			this.txtTelefon.ReadOnly = true;
			this.txtTelefon.Size = new System.Drawing.Size(100, 20);
			this.txtTelefon.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Telefon";
			// 
			// txtKontaktperson
			// 
			this.txtKontaktperson.Location = new System.Drawing.Point(95, 114);
			this.txtKontaktperson.Name = "txtKontaktperson";
			this.txtKontaktperson.ReadOnly = true;
			this.txtKontaktperson.Size = new System.Drawing.Size(100, 20);
			this.txtKontaktperson.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 117);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Kontaktperson";
			// 
			// FrmKarakter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 505);
			this.Controls.Add(this.txtKontaktperson);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtTelefon);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtAlder);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNavn);
			this.Controls.Add(this.label1);
			this.Name = "FrmKarakter";
			this.Text = "FrmKarakter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNavn;
		private System.Windows.Forms.TextBox txtAlder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTelefon;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtKontaktperson;
		private System.Windows.Forms.Label label5;
	}
}