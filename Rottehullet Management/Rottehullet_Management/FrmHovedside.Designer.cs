namespace Rottehullet_Management
{
    partial class FrmHovedside
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBeskrivelse = new System.Windows.Forms.TextBox();
			this.btnRedigerNavn = new System.Windows.Forms.Button();
			this.btnRedigerHjemmeside = new System.Windows.Forms.Button();
			this.btnRedigerBeskrivelse = new System.Windows.Forms.Button();
			this.txtNavn = new System.Windows.Forms.TextBox();
			this.txtHjemmeside = new System.Windows.Forms.TextBox();
			this.btnSkiftKampagne = new System.Windows.Forms.Button();
			this.btnRetAttributter = new System.Windows.Forms.Button();
			this.btnOpstartScenarie = new System.Windows.Forms.Button();
			this.btnÅbenKampagne = new System.Windows.Forms.Button();
			this.btnRetScenarie = new System.Windows.Forms.Button();
			this.btnPrintKarakterer = new System.Windows.Forms.Button();
			this.btnVælgSuperbruger = new System.Windows.Forms.Button();
			this.lstKarakterer = new System.Windows.Forms.ListView();
			this.KarakterID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.KarakterNavn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lstTilmeldte = new System.Windows.Forms.ListView();
			this.colKarakterID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colTilmeldte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnPrintTilmeldte = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Navn";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Hjemmeside";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Beskrivelse";
			// 
			// txtBeskrivelse
			// 
			this.txtBeskrivelse.Location = new System.Drawing.Point(16, 114);
			this.txtBeskrivelse.Multiline = true;
			this.txtBeskrivelse.Name = "txtBeskrivelse";
			this.txtBeskrivelse.ReadOnly = true;
			this.txtBeskrivelse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBeskrivelse.Size = new System.Drawing.Size(175, 145);
			this.txtBeskrivelse.TabIndex = 10;
			// 
			// btnRedigerNavn
			// 
			this.btnRedigerNavn.Location = new System.Drawing.Point(184, 15);
			this.btnRedigerNavn.Name = "btnRedigerNavn";
			this.btnRedigerNavn.Size = new System.Drawing.Size(21, 23);
			this.btnRedigerNavn.TabIndex = 1;
			this.btnRedigerNavn.UseVisualStyleBackColor = true;
			this.btnRedigerNavn.Click += new System.EventHandler(this.btnRedigerNavn_Click);
			// 
			// btnRedigerHjemmeside
			// 
			this.btnRedigerHjemmeside.Location = new System.Drawing.Point(184, 46);
			this.btnRedigerHjemmeside.Name = "btnRedigerHjemmeside";
			this.btnRedigerHjemmeside.Size = new System.Drawing.Size(21, 23);
			this.btnRedigerHjemmeside.TabIndex = 2;
			this.btnRedigerHjemmeside.UseVisualStyleBackColor = true;
			this.btnRedigerHjemmeside.Click += new System.EventHandler(this.btnRedigerHjemmeside_Click);
			// 
			// btnRedigerBeskrivelse
			// 
			this.btnRedigerBeskrivelse.Location = new System.Drawing.Point(79, 83);
			this.btnRedigerBeskrivelse.Name = "btnRedigerBeskrivelse";
			this.btnRedigerBeskrivelse.Size = new System.Drawing.Size(21, 23);
			this.btnRedigerBeskrivelse.TabIndex = 3;
			this.btnRedigerBeskrivelse.UseVisualStyleBackColor = true;
			this.btnRedigerBeskrivelse.Click += new System.EventHandler(this.btnRedigerBeskrivelse_Click);
			// 
			// txtNavn
			// 
			this.txtNavn.Location = new System.Drawing.Point(79, 15);
			this.txtNavn.Name = "txtNavn";
			this.txtNavn.ReadOnly = true;
			this.txtNavn.Size = new System.Drawing.Size(100, 20);
			this.txtNavn.TabIndex = 8;
			// 
			// txtHjemmeside
			// 
			this.txtHjemmeside.Location = new System.Drawing.Point(79, 49);
			this.txtHjemmeside.Name = "txtHjemmeside";
			this.txtHjemmeside.ReadOnly = true;
			this.txtHjemmeside.Size = new System.Drawing.Size(100, 20);
			this.txtHjemmeside.TabIndex = 9;
			// 
			// btnSkiftKampagne
			// 
			this.btnSkiftKampagne.Location = new System.Drawing.Point(16, 280);
			this.btnSkiftKampagne.Name = "btnSkiftKampagne";
			this.btnSkiftKampagne.Size = new System.Drawing.Size(93, 23);
			this.btnSkiftKampagne.TabIndex = 4;
			this.btnSkiftKampagne.Text = "Skift kampagne";
			this.btnSkiftKampagne.UseVisualStyleBackColor = true;
			this.btnSkiftKampagne.Click += new System.EventHandler(this.btnSkiftKampagne_Click);
			// 
			// btnRetAttributter
			// 
			this.btnRetAttributter.Location = new System.Drawing.Point(115, 280);
			this.btnRetAttributter.Name = "btnRetAttributter";
			this.btnRetAttributter.Size = new System.Drawing.Size(90, 23);
			this.btnRetAttributter.TabIndex = 5;
			this.btnRetAttributter.Text = "Ret attributter";
			this.btnRetAttributter.UseVisualStyleBackColor = true;
			this.btnRetAttributter.Click += new System.EventHandler(this.btnRetAttributter_Click);
			// 
			// btnOpstartScenarie
			// 
			this.btnOpstartScenarie.Location = new System.Drawing.Point(245, 206);
			this.btnOpstartScenarie.Name = "btnOpstartScenarie";
			this.btnOpstartScenarie.Size = new System.Drawing.Size(99, 23);
			this.btnOpstartScenarie.TabIndex = 6;
			this.btnOpstartScenarie.Text = "Opstart scenarie";
			this.btnOpstartScenarie.UseVisualStyleBackColor = true;
			this.btnOpstartScenarie.Click += new System.EventHandler(this.btnOpstartScenarie_Click);
			// 
			// btnÅbenKampagne
			// 
			this.btnÅbenKampagne.Location = new System.Drawing.Point(245, 280);
			this.btnÅbenKampagne.Name = "btnÅbenKampagne";
			this.btnÅbenKampagne.Size = new System.Drawing.Size(95, 23);
			this.btnÅbenKampagne.TabIndex = 7;
			this.btnÅbenKampagne.Text = "Åben/Luk";
			this.btnÅbenKampagne.UseVisualStyleBackColor = true;
			this.btnÅbenKampagne.Click += new System.EventHandler(this.btnÅbenKampagne_Click);
			// 
			// btnRetScenarie
			// 
			this.btnRetScenarie.Location = new System.Drawing.Point(245, 235);
			this.btnRetScenarie.Name = "btnRetScenarie";
			this.btnRetScenarie.Size = new System.Drawing.Size(99, 23);
			this.btnRetScenarie.TabIndex = 15;
			this.btnRetScenarie.Text = "Rediger scenarie";
			this.btnRetScenarie.UseVisualStyleBackColor = true;
			this.btnRetScenarie.Click += new System.EventHandler(this.btnRetScenarie_Click);
			// 
			// btnPrintKarakterer
			// 
			this.btnPrintKarakterer.Location = new System.Drawing.Point(532, 280);
			this.btnPrintKarakterer.Name = "btnPrintKarakterer";
			this.btnPrintKarakterer.Size = new System.Drawing.Size(120, 23);
			this.btnPrintKarakterer.TabIndex = 17;
			this.btnPrintKarakterer.Text = "Print";
			this.btnPrintKarakterer.UseVisualStyleBackColor = true;
			// 
			// btnVælgSuperbruger
			// 
			this.btnVælgSuperbruger.Location = new System.Drawing.Point(245, 177);
			this.btnVælgSuperbruger.Name = "btnVælgSuperbruger";
			this.btnVælgSuperbruger.Size = new System.Drawing.Size(99, 23);
			this.btnVælgSuperbruger.TabIndex = 0;
			this.btnVælgSuperbruger.Text = "Vælg superbruger";
			this.btnVælgSuperbruger.Click += new System.EventHandler(this.btnVælgSuperbruger_Click);
			// 
			// lstKarakterer
			// 
			this.lstKarakterer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.KarakterID,
            this.KarakterNavn});
			this.lstKarakterer.FullRowSelect = true;
			this.lstKarakterer.HideSelection = false;
			this.lstKarakterer.Location = new System.Drawing.Point(535, 15);
			this.lstKarakterer.Name = "lstKarakterer";
			this.lstKarakterer.Size = new System.Drawing.Size(121, 259);
			this.lstKarakterer.TabIndex = 19;
			this.lstKarakterer.UseCompatibleStateImageBehavior = false;
			this.lstKarakterer.View = System.Windows.Forms.View.Details;
			this.lstKarakterer.DoubleClick += new System.EventHandler(this.lstKarakterer_DoubleClick);
			// 
			// KarakterID
			// 
			this.KarakterID.Text = "";
			this.KarakterID.Width = 0;
			// 
			// KarakterNavn
			// 
			this.KarakterNavn.Text = "Alle Karakter";
			this.KarakterNavn.Width = 116;
			// 
			// lstTilmeldte
			// 
			this.lstTilmeldte.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKarakterID,
            this.colTilmeldte});
			this.lstTilmeldte.FullRowSelect = true;
			this.lstTilmeldte.Location = new System.Drawing.Point(393, 15);
			this.lstTilmeldte.Name = "lstTilmeldte";
			this.lstTilmeldte.Size = new System.Drawing.Size(121, 259);
			this.lstTilmeldte.TabIndex = 20;
			this.lstTilmeldte.UseCompatibleStateImageBehavior = false;
			this.lstTilmeldte.View = System.Windows.Forms.View.Details;
			this.lstTilmeldte.DoubleClick += new System.EventHandler(this.lstTilmeldte_DoubleClick);
			// 
			// colKarakterID
			// 
			this.colKarakterID.Text = "";
			this.colKarakterID.Width = 0;
			// 
			// colTilmeldte
			// 
			this.colTilmeldte.Text = "Tilmeldte Karakterer";
			this.colTilmeldte.Width = 117;
			// 
			// btnPrintTilmeldte
			// 
			this.btnPrintTilmeldte.Location = new System.Drawing.Point(393, 280);
			this.btnPrintTilmeldte.Name = "btnPrintTilmeldte";
			this.btnPrintTilmeldte.Size = new System.Drawing.Size(120, 23);
			this.btnPrintTilmeldte.TabIndex = 21;
			this.btnPrintTilmeldte.Text = "Print";
			this.btnPrintTilmeldte.UseVisualStyleBackColor = true;
			// 
			// FrmHovedside
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 315);
			this.Controls.Add(this.btnPrintTilmeldte);
			this.Controls.Add(this.lstTilmeldte);
			this.Controls.Add(this.lstKarakterer);
			this.Controls.Add(this.btnVælgSuperbruger);
			this.Controls.Add(this.btnPrintKarakterer);
			this.Controls.Add(this.btnRetScenarie);
			this.Controls.Add(this.btnÅbenKampagne);
			this.Controls.Add(this.btnOpstartScenarie);
			this.Controls.Add(this.btnRetAttributter);
			this.Controls.Add(this.btnSkiftKampagne);
			this.Controls.Add(this.txtHjemmeside);
			this.Controls.Add(this.txtNavn);
			this.Controls.Add(this.btnRedigerBeskrivelse);
			this.Controls.Add(this.btnRedigerHjemmeside);
			this.Controls.Add(this.btnRedigerNavn);
			this.Controls.Add(this.txtBeskrivelse);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmHovedside";
			this.Text = "Kampagne Manager";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBeskrivelse;
        private System.Windows.Forms.Button btnRedigerNavn;
        private System.Windows.Forms.Button btnRedigerHjemmeside;
        private System.Windows.Forms.Button btnRedigerBeskrivelse;
        private System.Windows.Forms.TextBox txtNavn;
        private System.Windows.Forms.TextBox txtHjemmeside;
        private System.Windows.Forms.Button btnSkiftKampagne;
        private System.Windows.Forms.Button btnRetAttributter;
		private System.Windows.Forms.Button btnOpstartScenarie;
		private System.Windows.Forms.Button btnÅbenKampagne;
		private System.Windows.Forms.Button btnRetScenarie;
		private System.Windows.Forms.Button btnVælgSuperbruger;
		private System.Windows.Forms.Button btnPrintKarakterer;
		private System.Windows.Forms.ListView lstKarakterer;
		private System.Windows.Forms.ColumnHeader KarakterID;
		private System.Windows.Forms.ColumnHeader KarakterNavn;
		private System.Windows.Forms.ListView lstTilmeldte;
		private System.Windows.Forms.ColumnHeader colKarakterID;
		private System.Windows.Forms.ColumnHeader colTilmeldte;
		private System.Windows.Forms.Button btnPrintTilmeldte;

    }
}