namespace MoveMe.WinForms.Dashboard
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.lblNumberOfClients = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtClients = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSuppliers = new System.Windows.Forms.Label();
            this.lblNumberOfSuppliers = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRequests = new System.Windows.Forms.Label();
            this.lblNumberOfRequests = new System.Windows.Forms.Label();
            this.Overview = new System.Windows.Forms.Label();
            this.lblRequests = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRequestReport = new System.Windows.Forms.Button();
            this.btnReportMostActive = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumberOfClients
            // 
            this.lblNumberOfClients.AutoSize = true;
            this.lblNumberOfClients.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfClients.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberOfClients.Location = new System.Drawing.Point(45, 16);
            this.lblNumberOfClients.Name = "lblNumberOfClients";
            this.lblNumberOfClients.Size = new System.Drawing.Size(124, 41);
            this.lblNumberOfClients.TabIndex = 0;
            this.lblNumberOfClients.Text = "Clients";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.groupBox1.Controls.Add(this.txtClients);
            this.groupBox1.Controls.Add(this.lblNumberOfClients);
            this.groupBox1.Location = new System.Drawing.Point(34, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtClients
            // 
            this.txtClients.AutoSize = true;
            this.txtClients.Font = new System.Drawing.Font("Bahnschrift SemiLight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClients.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtClients.Location = new System.Drawing.Point(47, 58);
            this.txtClients.Name = "txtClients";
            this.txtClients.Size = new System.Drawing.Size(113, 29);
            this.txtClients.TabIndex = 1;
            this.txtClients.Text = "Loading...";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.txtSuppliers);
            this.groupBox2.Controls.Add(this.lblNumberOfSuppliers);
            this.groupBox2.Location = new System.Drawing.Point(292, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // txtSuppliers
            // 
            this.txtSuppliers.AutoSize = true;
            this.txtSuppliers.Font = new System.Drawing.Font("Bahnschrift SemiLight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuppliers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSuppliers.Location = new System.Drawing.Point(51, 58);
            this.txtSuppliers.Name = "txtSuppliers";
            this.txtSuppliers.Size = new System.Drawing.Size(113, 29);
            this.txtSuppliers.TabIndex = 2;
            this.txtSuppliers.Text = "Loading...";
            // 
            // lblNumberOfSuppliers
            // 
            this.lblNumberOfSuppliers.AutoSize = true;
            this.lblNumberOfSuppliers.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfSuppliers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberOfSuppliers.Location = new System.Drawing.Point(49, 16);
            this.lblNumberOfSuppliers.Name = "lblNumberOfSuppliers";
            this.lblNumberOfSuppliers.Size = new System.Drawing.Size(164, 41);
            this.lblNumberOfSuppliers.TabIndex = 1;
            this.lblNumberOfSuppliers.Text = "Suppliers";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox3.Controls.Add(this.txtRequests);
            this.groupBox3.Controls.Add(this.lblNumberOfRequests);
            this.groupBox3.Location = new System.Drawing.Point(551, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtRequests
            // 
            this.txtRequests.AutoSize = true;
            this.txtRequests.Font = new System.Drawing.Font("Bahnschrift SemiLight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequests.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtRequests.Location = new System.Drawing.Point(52, 58);
            this.txtRequests.Name = "txtRequests";
            this.txtRequests.Size = new System.Drawing.Size(113, 29);
            this.txtRequests.TabIndex = 3;
            this.txtRequests.Text = "Loading...";
            // 
            // lblNumberOfRequests
            // 
            this.lblNumberOfRequests.AutoSize = true;
            this.lblNumberOfRequests.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRequests.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberOfRequests.Location = new System.Drawing.Point(49, 16);
            this.lblNumberOfRequests.Name = "lblNumberOfRequests";
            this.lblNumberOfRequests.Size = new System.Drawing.Size(159, 41);
            this.lblNumberOfRequests.TabIndex = 2;
            this.lblNumberOfRequests.Text = "Requests";
            // 
            // Overview
            // 
            this.Overview.Dock = System.Windows.Forms.DockStyle.Top;
            this.Overview.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Overview.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Overview.Location = new System.Drawing.Point(0, 0);
            this.Overview.Margin = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.Overview.Name = "Overview";
            this.Overview.Padding = new System.Windows.Forms.Padding(22, 24, 22, 8);
            this.Overview.Size = new System.Drawing.Size(800, 66);
            this.Overview.TabIndex = 2;
            this.Overview.Text = "Overview";
            // 
            // lblRequests
            // 
            this.lblRequests.AutoSize = true;
            this.lblRequests.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequests.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRequests.Location = new System.Drawing.Point(34, 219);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(254, 41);
            this.lblRequests.TabIndex = 5;
            this.lblRequests.Text = "Latest requests";
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestId,
            this.Date,
            this.Client,
            this.From,
            this.To,
            this.Price,
            this.Status});
            this.dgvRequests.Location = new System.Drawing.Point(40, 264);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(724, 198);
            this.dgvRequests.TabIndex = 6;
            this.dgvRequests.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellDoubleClick);
            // 
            // RequestId
            // 
            this.RequestId.DataPropertyName = "RequestId";
            this.RequestId.HeaderText = "RequestId";
            this.RequestId.MinimumWidth = 6;
            this.RequestId.Name = "RequestId";
            this.RequestId.ReadOnly = true;
            this.RequestId.Visible = false;
            this.RequestId.Width = 125;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 125;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Client";
            this.Client.MinimumWidth = 6;
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.Width = 125;
            // 
            // From
            // 
            this.From.DataPropertyName = "From";
            this.From.HeaderText = "From";
            this.From.MinimumWidth = 6;
            this.From.Name = "From";
            this.From.ReadOnly = true;
            this.From.Width = 125;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "To";
            this.To.MinimumWidth = 6;
            this.To.Name = "To";
            this.To.ReadOnly = true;
            this.To.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 125;
            // 
            // btnRequestReport
            // 
            this.btnRequestReport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRequestReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRequestReport.Location = new System.Drawing.Point(214, 194);
            this.btnRequestReport.Name = "btnRequestReport";
            this.btnRequestReport.Size = new System.Drawing.Size(166, 31);
            this.btnRequestReport.TabIndex = 8;
            this.btnRequestReport.Text = "Request report";
            this.btnRequestReport.UseVisualStyleBackColor = false;
            this.btnRequestReport.Click += new System.EventHandler(this.btnRequestReport_Click);
            // 
            // btnReportMostActive
            // 
            this.btnReportMostActive.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReportMostActive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReportMostActive.Location = new System.Drawing.Point(404, 194);
            this.btnReportMostActive.Name = "btnReportMostActive";
            this.btnReportMostActive.Size = new System.Drawing.Size(184, 31);
            this.btnReportMostActive.TabIndex = 10;
            this.btnReportMostActive.Text = "Report of most active users";
            this.btnReportMostActive.UseVisualStyleBackColor = false;
            this.btnReportMostActive.Click += new System.EventHandler(this.btnReportMostActive_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(0, 66);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(800, 119);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnReportMostActive);
            this.Controls.Add(this.btnRequestReport);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.Overview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberOfClients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtClients;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtSuppliers;
        private System.Windows.Forms.Label lblNumberOfSuppliers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txtRequests;
        private System.Windows.Forms.Label lblNumberOfRequests;
        private System.Windows.Forms.Label Overview;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnRequestReport;
        private System.Windows.Forms.Button btnReportMostActive;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}