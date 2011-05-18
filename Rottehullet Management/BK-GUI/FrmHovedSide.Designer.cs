namespace BK_GUI
{
    partial class FrmHovedSide
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
            this.lstkaraktere = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.karakternavn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNyOpdaterDisabled = new System.Windows.Forms.Button();
            this.btnTilmeldTilScenarie = new System.Windows.Forms.Button();
            this.btnSkiftKampagne = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNavn = new System.Windows.Forms.TextBox();
            this.txtTidspunkt = new System.Windows.Forms.TextBox();
            this.txtSted = new System.Windows.Forms.TextBox();
            this.txtPris = new System.Windows.Forms.TextBox();
            this.txtBeskrivelse = new System.Windows.Forms.TextBox();
            this.txtAndetInfo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOvernatninger = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstkaraktere
            // 
            this.lstkaraktere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.karakternavn});
            this.lstkaraktere.FullRowSelect = true;
            this.lstkaraktere.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstkaraktere.Location = new System.Drawing.Point(2, 19);
            this.lstkaraktere.Name = "lstkaraktere";
            this.lstkaraktere.Size = new System.Drawing.Size(192, 163);
            this.lstkaraktere.TabIndex = 0;
            this.lstkaraktere.UseCompatibleStateImageBehavior = false;
            this.lstkaraktere.View = System.Windows.Forms.View.Details;
            this.lstkaraktere.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstkaraktere_MouseClick);
            // 
            // ID
            // 
            this.ID.Text = "";
            this.ID.Width = 0;
            // 
            // karakternavn
            // 
            this.karakternavn.Text = "Navn";
            this.karakternavn.Width = 188;
            // 
            // btnNyOpdaterDisabled
            // 
            this.btnNyOpdaterDisabled.Location = new System.Drawing.Point(24, 188);
            this.btnNyOpdaterDisabled.Name = "btnNyOpdaterDisabled";
            this.btnNyOpdaterDisabled.Size = new System.Drawing.Size(153, 23);
            this.btnNyOpdaterDisabled.TabIndex = 2;
            this.btnNyOpdaterDisabled.Text = "Ny/Opdater";
            this.btnNyOpdaterDisabled.UseVisualStyleBackColor = true;
            this.btnNyOpdaterDisabled.Click += new System.EventHandler(this.btnNyOpdaterDisabled_Click);
            // 
            // btnTilmeldTilScenarie
            // 
            this.btnTilmeldTilScenarie.Location = new System.Drawing.Point(24, 341);
            this.btnTilmeldTilScenarie.Name = "btnTilmeldTilScenarie";
            this.btnTilmeldTilScenarie.Size = new System.Drawing.Size(153, 23);
            this.btnTilmeldTilScenarie.TabIndex = 3;
            this.btnTilmeldTilScenarie.Text = "Tilmeld Karakter til Scenarie";
            this.btnTilmeldTilScenarie.UseVisualStyleBackColor = true;
            this.btnTilmeldTilScenarie.Click += new System.EventHandler(this.btnTilmeldTilScenarie_Click);
            // 
            // btnSkiftKampagne
            // 
            this.btnSkiftKampagne.Location = new System.Drawing.Point(35, 594);
            this.btnSkiftKampagne.Name = "btnSkiftKampagne";
            this.btnSkiftKampagne.Size = new System.Drawing.Size(153, 23);
            this.btnSkiftKampagne.TabIndex = 4;
            this.btnSkiftKampagne.Text = "Skift Kampagne";
            this.btnSkiftKampagne.UseVisualStyleBackColor = true;
            this.btnSkiftKampagne.Click += new System.EventHandler(this.btnSkiftKampagne_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstkaraktere);
            this.groupBox1.Controls.Add(this.btnNyOpdaterDisabled);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 213);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Karakter";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOvernatninger);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtAndetInfo);
            this.groupBox2.Controls.Add(this.txtTidspunkt);
            this.groupBox2.Controls.Add(this.txtBeskrivelse);
            this.groupBox2.Controls.Add(this.txtPris);
            this.groupBox2.Controls.Add(this.txtSted);
            this.groupBox2.Controls.Add(this.txtNavn);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnTilmeldTilScenarie);
            this.groupBox2.Location = new System.Drawing.Point(12, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 368);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scenarie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Navn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tidspunkt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sted";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pris";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Beskrivelse";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Andet info";
            // 
            // txtNavn
            // 
            this.txtNavn.Location = new System.Drawing.Point(68, 13);
            this.txtNavn.Name = "txtNavn";
            this.txtNavn.ReadOnly = true;
            this.txtNavn.Size = new System.Drawing.Size(100, 20);
            this.txtNavn.TabIndex = 10;
            // 
            // txtTidspunkt
            // 
            this.txtTidspunkt.Location = new System.Drawing.Point(68, 38);
            this.txtTidspunkt.Name = "txtTidspunkt";
            this.txtTidspunkt.ReadOnly = true;
            this.txtTidspunkt.Size = new System.Drawing.Size(132, 20);
            this.txtTidspunkt.TabIndex = 11;
            // 
            // txtSted
            // 
            this.txtSted.Location = new System.Drawing.Point(68, 64);
            this.txtSted.Name = "txtSted";
            this.txtSted.ReadOnly = true;
            this.txtSted.Size = new System.Drawing.Size(100, 20);
            this.txtSted.TabIndex = 12;
            // 
            // txtPris
            // 
            this.txtPris.Location = new System.Drawing.Point(68, 89);
            this.txtPris.Name = "txtPris";
            this.txtPris.ReadOnly = true;
            this.txtPris.Size = new System.Drawing.Size(100, 20);
            this.txtPris.TabIndex = 13;
            // 
            // txtBeskrivelse
            // 
            this.txtBeskrivelse.Location = new System.Drawing.Point(10, 131);
            this.txtBeskrivelse.Multiline = true;
            this.txtBeskrivelse.Name = "txtBeskrivelse";
            this.txtBeskrivelse.ReadOnly = true;
            this.txtBeskrivelse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBeskrivelse.Size = new System.Drawing.Size(158, 66);
            this.txtBeskrivelse.TabIndex = 14;
            // 
            // txtAndetInfo
            // 
            this.txtAndetInfo.Location = new System.Drawing.Point(6, 246);
            this.txtAndetInfo.Multiline = true;
            this.txtAndetInfo.Name = "txtAndetInfo";
            this.txtAndetInfo.ReadOnly = true;
            this.txtAndetInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAndetInfo.Size = new System.Drawing.Size(162, 89);
            this.txtAndetInfo.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Overnatninger";
            // 
            // txtOvernatninger
            // 
            this.txtOvernatninger.Location = new System.Drawing.Point(86, 203);
            this.txtOvernatninger.Name = "txtOvernatninger";
            this.txtOvernatninger.ReadOnly = true;
            this.txtOvernatninger.Size = new System.Drawing.Size(82, 20);
            this.txtOvernatninger.TabIndex = 17;
            // 
            // FrmHovedSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 619);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSkiftKampagne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmHovedSide";
            this.Text = "HovedSide";
            this.Load += new System.EventHandler(this.FrmHovedSide_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ListView lstkaraktere;
        private System.Windows.Forms.Button btnNyOpdaterDisabled;
        private System.Windows.Forms.Button btnTilmeldTilScenarie;
        private System.Windows.Forms.Button btnSkiftKampagne;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader karakternavn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBeskrivelse;
        private System.Windows.Forms.TextBox txtPris;
        private System.Windows.Forms.TextBox txtSted;
        private System.Windows.Forms.TextBox txtTidspunkt;
        private System.Windows.Forms.TextBox txtNavn;
        private System.Windows.Forms.TextBox txtAndetInfo;
        private System.Windows.Forms.TextBox txtOvernatninger;
        private System.Windows.Forms.Label label7;
    }
}