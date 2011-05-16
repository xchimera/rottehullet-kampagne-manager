namespace Rottehullet_Management
{
	partial class FrmKampagneKaraktererOverblik
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
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.IKarakterBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.IKarakterBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.IKarakterBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rottehullet_Management.RapKampagneKarakterer.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(1, -1);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(725, 395);
			this.reportViewer1.TabIndex = 0;
			// 
			// IKarakterBindingSource
			// 
			this.IKarakterBindingSource.DataSource = typeof(Interfaces.IKarakter);
			// 
			// FrmKampagneKaraktererOverblik
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 391);
			this.Controls.Add(this.reportViewer1);
			this.Name = "FrmKampagneKaraktererOverblik";
			this.Text = "FrmKampagneKaraktererOverblik";
			this.Load += new System.EventHandler(this.FrmKampagneKaraktererOverblik_Load);
			((System.ComponentModel.ISupportInitialize)(this.IKarakterBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource IKarakterBindingSource;
	}
}