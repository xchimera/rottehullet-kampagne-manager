namespace BK_GUI
{
    partial class FrmScenarieTilmelding
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
            this.chkSpisning = new System.Windows.Forms.CheckBox();
            this.txtOvernatning = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotaleOvernatninger = new System.Windows.Forms.Label();
            this.btnTilmeld = new System.Windows.Forms.Button();
            this.btnAnnuller = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSpisning
            // 
            this.chkSpisning.AutoSize = true;
            this.chkSpisning.Location = new System.Drawing.Point(133, 64);
            this.chkSpisning.Name = "chkSpisning";
            this.chkSpisning.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSpisning.Size = new System.Drawing.Size(66, 17);
            this.chkSpisning.TabIndex = 0;
            this.chkSpisning.Text = "Spisning";
            this.chkSpisning.UseVisualStyleBackColor = true;
            // 
            // txtOvernatning
            // 
            this.txtOvernatning.Location = new System.Drawing.Point(158, 22);
            this.txtOvernatning.Name = "txtOvernatning";
            this.txtOvernatning.Size = new System.Drawing.Size(50, 20);
            this.txtOvernatning.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Antal Overnatninger";
            // 
            // lblTotaleOvernatninger
            // 
            this.lblTotaleOvernatninger.AutoSize = true;
            this.lblTotaleOvernatninger.Location = new System.Drawing.Point(45, 35);
            this.lblTotaleOvernatninger.Name = "lblTotaleOvernatninger";
            this.lblTotaleOvernatninger.Size = new System.Drawing.Size(83, 13);
            this.lblTotaleOvernatninger.TabIndex = 3;
            this.lblTotaleOvernatninger.Text = "<mangler kode>";
            // 
            // btnTilmeld
            // 
            this.btnTilmeld.Location = new System.Drawing.Point(30, 163);
            this.btnTilmeld.Name = "btnTilmeld";
            this.btnTilmeld.Size = new System.Drawing.Size(75, 23);
            this.btnTilmeld.TabIndex = 4;
            this.btnTilmeld.Text = "Tilmeld";
            this.btnTilmeld.UseVisualStyleBackColor = true;
            this.btnTilmeld.Click += new System.EventHandler(this.btnTilmeld_Click);
            // 
            // btnAnnuller
            // 
            this.btnAnnuller.Location = new System.Drawing.Point(133, 163);
            this.btnAnnuller.Name = "btnAnnuller";
            this.btnAnnuller.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuller.TabIndex = 5;
            this.btnAnnuller.Text = "Annuller";
            this.btnAnnuller.UseVisualStyleBackColor = true;
            this.btnAnnuller.Click += new System.EventHandler(this.btnAnnuller_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Location = new System.Drawing.Point(215, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 173);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scenarie Information";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(7, 20);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(252, 147);
            this.txtInfo.TabIndex = 0;
            // 
            // FrmScenarieTilmelding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 198);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnnuller);
            this.Controls.Add(this.btnTilmeld);
            this.Controls.Add(this.lblTotaleOvernatninger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOvernatning);
            this.Controls.Add(this.chkSpisning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmScenarieTilmelding";
            this.Text = "Scenarie Tilmelding";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSpisning;
        private System.Windows.Forms.TextBox txtOvernatning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotaleOvernatninger;
        private System.Windows.Forms.Button btnTilmeld;
        private System.Windows.Forms.Button btnAnnuller;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtInfo;
    }
}