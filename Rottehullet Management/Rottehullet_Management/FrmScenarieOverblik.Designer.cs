namespace Rottehullet_Management
{
	partial class FrmScenarieOverblik
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.ITilmeldingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.kampagneManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.IScenarieBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ITilmeldingBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kampagneManagerBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IScenarieBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ITilmeldingBindingSource
			// 
			this.ITilmeldingBindingSource.DataSource = typeof(Interfaces.ITilmelding);
			// 
			// reportViewer1
			// 
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.ITilmeldingBindingSource;
			reportDataSource2.Name = "DataSet2";
			reportDataSource2.Value = this.IScenarieBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "Rottehullet_Management.RapScenarie.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(770, 400);
			this.reportViewer1.TabIndex = 0;
			// 
			// kampagneManagerBindingSource
			// 
			this.kampagneManagerBindingSource.DataSource = typeof(Controller.KampagneManager);
			// 
			// IScenarieBindingSource
			// 
			this.IScenarieBindingSource.DataSource = typeof(Interfaces.IScenarie);
			// 
			// FrmScenarieOverblik
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(769, 399);
			this.Controls.Add(this.reportViewer1);
			this.Name = "FrmScenarieOverblik";
			this.Text = "FrmScenarieOverblik";
			this.Load += new System.EventHandler(this.FrmScenarieOverblik_Load);
			((System.ComponentModel.ISupportInitialize)(this.ITilmeldingBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kampagneManagerBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IScenarieBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource ITilmeldingBindingSource;
		private System.Windows.Forms.BindingSource kampagneManagerBindingSource;
		private System.Windows.Forms.BindingSource IScenarieBindingSource;
	}
}