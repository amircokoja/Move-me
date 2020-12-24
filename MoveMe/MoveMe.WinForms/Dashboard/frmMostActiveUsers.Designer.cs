namespace MoveMe.WinForms.Dashboard
{
    partial class frmMostActiveUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMostActiveUsers));
            this.SupplierReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvMostActive = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SupplierReportBindingSource
            // 
            this.SupplierReportBindingSource.DataSource = typeof(MoveMe.WinForms.Models.SupplierReport);
            // 
            // ClientReportBindingSource
            // 
            this.ClientReportBindingSource.DataSource = typeof(MoveMe.WinForms.Models.ClientReport);
            // 
            // rvMostActive
            // 
            this.rvMostActive.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SupplierDataSet";
            reportDataSource1.Value = this.SupplierReportBindingSource;
            reportDataSource2.Name = "ClientDataSet";
            reportDataSource2.Value = this.ClientReportBindingSource;
            this.rvMostActive.LocalReport.DataSources.Add(reportDataSource1);
            this.rvMostActive.LocalReport.DataSources.Add(reportDataSource2);
            this.rvMostActive.LocalReport.ReportEmbeddedResource = "MoveMe.WinForms.Dashboard.ReportMostActiveUsers.rdlc";
            this.rvMostActive.Location = new System.Drawing.Point(0, 0);
            this.rvMostActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvMostActive.Name = "rvMostActive";
            this.rvMostActive.ServerReport.BearerToken = null;
            this.rvMostActive.Size = new System.Drawing.Size(1067, 554);
            this.rvMostActive.TabIndex = 0;
            // 
            // frmMostActiveUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvMostActive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMostActiveUsers";
            this.Text = "Report - most active users";
            this.Load += new System.EventHandler(this.frmMostActiveUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvMostActive;
        private System.Windows.Forms.BindingSource SupplierReportBindingSource;
        private System.Windows.Forms.BindingSource ClientReportBindingSource;
    }
}