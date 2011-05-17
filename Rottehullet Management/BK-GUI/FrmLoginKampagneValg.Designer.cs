namespace BK_GUI
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
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Navn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVælgKampagne = new System.Windows.Forms.Button();
            this.btnRedigerBrugerInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNavn = new System.Windows.Forms.TextBox();
            this.txtHjemmeside = new System.Windows.Forms.TextBox();
            this.txtBeskrivelse = new System.Windows.Forms.TextBox();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.txtScenarieBeskrivelse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtScenarieNavn = new System.Windows.Forms.TextBox();
            this.txtPris = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstKampagner
            // 
            this.lstKampagner.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Navn});
            this.lstKampagner.FullRowSelect = true;
            this.lstKampagner.Location = new System.Drawing.Point(12, 12);
            this.lstKampagner.Name = "lstKampagner";
            this.lstKampagner.Size = new System.Drawing.Size(260, 326);
            this.lstKampagner.TabIndex = 0;
            this.lstKampagner.UseCompatibleStateImageBehavior = false;
            this.lstKampagner.View = System.Windows.Forms.View.Details;
            this.lstKampagner.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstKampagner_MouseClick);
            this.lstKampagner.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstKampagner_MouseDoubleClick);
            // 
            // ID
            // 
            this.ID.Text = "";
            this.ID.Width = 0;
            // 
            // Navn
            // 
            this.Navn.Text = "Navn";
            this.Navn.Width = 256;
            // 
            // btnVælgKampagne
            // 
            this.btnVælgKampagne.Location = new System.Drawing.Point(12, 344);
            this.btnVælgKampagne.Name = "btnVælgKampagne";
            this.btnVælgKampagne.Size = new System.Drawing.Size(94, 23);
            this.btnVælgKampagne.TabIndex = 1;
            this.btnVælgKampagne.Text = "Vælg kampagne";
            this.btnVælgKampagne.UseVisualStyleBackColor = true;
            this.btnVælgKampagne.Click += new System.EventHandler(this.btnVælgKampagne_Click);
            // 
            // btnRedigerBrugerInfo
            // 
            this.btnRedigerBrugerInfo.Location = new System.Drawing.Point(178, 344);
            this.btnRedigerBrugerInfo.Name = "btnRedigerBrugerInfo";
            this.btnRedigerBrugerInfo.Size = new System.Drawing.Size(94, 44);
            this.btnRedigerBrugerInfo.TabIndex = 2;
            this.btnRedigerBrugerInfo.Text = "Rediger Bruger Information";
            this.btnRedigerBrugerInfo.UseVisualStyleBackColor = true;
            this.btnRedigerBrugerInfo.Click += new System.EventHandler(this.btnbtnRedigerBrugerInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Navn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hjemmeside";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Beskrivelse";
            // 
            // txtNavn
            // 
            this.txtNavn.Enabled = false;
            this.txtNavn.Location = new System.Drawing.Point(73, 27);
            this.txtNavn.Name = "txtNavn";
            this.txtNavn.Size = new System.Drawing.Size(100, 20);
            this.txtNavn.TabIndex = 6;
            // 
            // txtHjemmeside
            // 
            this.txtHjemmeside.Enabled = false;
            this.txtHjemmeside.Location = new System.Drawing.Point(73, 51);
            this.txtHjemmeside.Name = "txtHjemmeside";
            this.txtHjemmeside.Size = new System.Drawing.Size(100, 20);
            this.txtHjemmeside.TabIndex = 7;
            // 
            // txtBeskrivelse
            // 
            this.txtBeskrivelse.Enabled = false;
            this.txtBeskrivelse.Location = new System.Drawing.Point(9, 95);
            this.txtBeskrivelse.Multiline = true;
            this.txtBeskrivelse.Name = "txtBeskrivelse";
            this.txtBeskrivelse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBeskrivelse.Size = new System.Drawing.Size(175, 81);
            this.txtBeskrivelse.TabIndex = 8;
            // 
            // txtDato
            // 
            this.txtDato.Enabled = false;
            this.txtDato.Location = new System.Drawing.Point(73, 79);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(100, 20);
            this.txtDato.TabIndex = 10;
            // 
            // txtScenarieBeskrivelse
            // 
            this.txtScenarieBeskrivelse.Enabled = false;
            this.txtScenarieBeskrivelse.Location = new System.Drawing.Point(9, 127);
            this.txtScenarieBeskrivelse.Multiline = true;
            this.txtScenarieBeskrivelse.Name = "txtScenarieBeskrivelse";
            this.txtScenarieBeskrivelse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScenarieBeskrivelse.Size = new System.Drawing.Size(175, 81);
            this.txtScenarieBeskrivelse.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Dato";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Beskrivelse";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBeskrivelse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNavn);
            this.groupBox1.Controls.Add(this.txtHjemmeside);
            this.groupBox1.Location = new System.Drawing.Point(278, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 184);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kampagne";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPris);
            this.groupBox2.Controls.Add(this.txtScenarieNavn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDato);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtScenarieBeskrivelse);
            this.groupBox2.Location = new System.Drawing.Point(278, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 216);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Næste scenarie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Navn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Pris";
            // 
            // txtScenarieNavn
            // 
            this.txtScenarieNavn.Location = new System.Drawing.Point(73, 27);
            this.txtScenarieNavn.Name = "txtScenarieNavn";
            this.txtScenarieNavn.Size = new System.Drawing.Size(100, 20);
            this.txtScenarieNavn.TabIndex = 16;
            // 
            // txtPris
            // 
            this.txtPris.Location = new System.Drawing.Point(73, 53);
            this.txtPris.Name = "txtPris";
            this.txtPris.Size = new System.Drawing.Size(100, 20);
            this.txtPris.TabIndex = 17;
            // 
            // FrmLoginKampagneValg
            // 
            this.AcceptButton = this.btnVælgKampagne;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 425);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRedigerBrugerInfo);
            this.Controls.Add(this.btnVælgKampagne);
            this.Controls.Add(this.lstKampagner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLoginKampagneValg";
            this.Text = "Kampagne valg";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstKampagner;
        private System.Windows.Forms.Button btnVælgKampagne;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Navn;
		private System.Windows.Forms.Button btnRedigerBrugerInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNavn;
        private System.Windows.Forms.TextBox txtHjemmeside;
        private System.Windows.Forms.TextBox txtBeskrivelse;
        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.TextBox txtScenarieBeskrivelse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPris;
        private System.Windows.Forms.TextBox txtScenarieNavn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
    }
}