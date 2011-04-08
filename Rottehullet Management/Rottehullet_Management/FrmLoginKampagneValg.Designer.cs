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
			this.btnKampagne2 = new System.Windows.Forms.Button();
			this.btnKampagne3 = new System.Windows.Forms.Button();
			this.btnKampagne1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnKampagne2
			// 
			this.btnKampagne2.Location = new System.Drawing.Point(12, 41);
			this.btnKampagne2.Name = "btnKampagne2";
			this.btnKampagne2.Size = new System.Drawing.Size(283, 23);
			this.btnKampagne2.TabIndex = 1;
			this.btnKampagne2.Text = "button1";
			this.btnKampagne2.UseVisualStyleBackColor = true;
			this.btnKampagne2.Click += new System.EventHandler(this.btnKampagne2_Click);
			// 
			// btnKampagne3
			// 
			this.btnKampagne3.Enabled = false;
			this.btnKampagne3.Location = new System.Drawing.Point(12, 70);
			this.btnKampagne3.Name = "btnKampagne3";
			this.btnKampagne3.Size = new System.Drawing.Size(283, 23);
			this.btnKampagne3.TabIndex = 2;
			this.btnKampagne3.Text = "Ingen Kampagne";
			this.btnKampagne3.UseVisualStyleBackColor = true;
			this.btnKampagne3.Click += new System.EventHandler(this.btnKampagne3_Click);
			// 
			// btnKampagne1
			// 
			this.btnKampagne1.Location = new System.Drawing.Point(12, 12);
			this.btnKampagne1.Name = "btnKampagne1";
			this.btnKampagne1.Size = new System.Drawing.Size(283, 23);
			this.btnKampagne1.TabIndex = 3;
			this.btnKampagne1.Text = "button3";
			this.btnKampagne1.UseVisualStyleBackColor = true;
			this.btnKampagne1.Click += new System.EventHandler(this.btnKampagne1_Click);
			// 
			// FrmLoginKampagneValg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(307, 105);
			this.Controls.Add(this.btnKampagne1);
			this.Controls.Add(this.btnKampagne3);
			this.Controls.Add(this.btnKampagne2);
			this.Name = "FrmLoginKampagneValg";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnKampagne2;
		private System.Windows.Forms.Button btnKampagne3;
		private System.Windows.Forms.Button btnKampagne1;

	}
}