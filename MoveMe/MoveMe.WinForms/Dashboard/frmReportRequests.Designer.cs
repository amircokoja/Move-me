namespace MoveMe.WinForms.Dashboard
{
    partial class frmReportRequests
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportRequests));
            this.RequestReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvRequests = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.RequestReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RequestReportBindingSource
            // 
            this.RequestReportBindingSource.DataSource = typeof(MoveMe.WinForms.Models.RequestReport);
            // 
            // rvRequests
            // 
            this.rvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "RequestDataSet";
            reportDataSource2.Value = this.RequestReportBindingSource;
            this.rvRequests.LocalReport.DataSources.Add(reportDataSource2);
            this.rvRequests.LocalReport.ReportEmbeddedResource = "MoveMe.WinForms.Dashboard.ReportRequests.rdlc";
            this.rvRequests.Location = new System.Drawing.Point(0, 0);
            this.rvRequests.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvRequests.Name = "rvRequests";
            this.rvRequests.ServerReport.BearerToken = null;
            this.rvRequests.Size = new System.Drawing.Size(1067, 554);
            this.rvRequests.TabIndex = 0;
            // 
            // frmReportRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvRequests);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReportRequests";
            this.Text = "Report - finished requests";
            this.Load += new System.EventHandler(this.frmReportRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RequestReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvRequests;
        private System.Windows.Forms.BindingSource RequestReportBindingSource;
    }
}