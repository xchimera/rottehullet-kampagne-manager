﻿namespace Rottehullet_Management
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAttributter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Opret kampagne";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Slet bruger";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnAttributter
            // 
            this.btnAttributter.Location = new System.Drawing.Point(13, 73);
            this.btnAttributter.Name = "btnAttributter";
            this.btnAttributter.Size = new System.Drawing.Size(259, 23);
            this.btnAttributter.TabIndex = 2;
            this.btnAttributter.Text = "Attributter";
            this.btnAttributter.UseVisualStyleBackColor = true;
            this.btnAttributter.Click += new System.EventHandler(this.btnAttributter_Click);
            // 
            // FrmAdminSektion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnAttributter);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmAdminSektion";
            this.Text = "Administration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAttributter;
    }
}