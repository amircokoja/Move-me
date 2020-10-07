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
            this.lblNumberOfClients = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNumberOfSuppliers = new System.Windows.Forms.Label();
            this.lblNumberOfRequests = new System.Windows.Forms.Label();
            this.Clients = new System.Windows.Forms.Label();
            this.Suppliers = new System.Windows.Forms.Label();
            this.Requests = new System.Windows.Forms.Label();
            this.Overview = new System.Windows.Forms.Label();
            this.lblRequests = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfClients
            // 
            this.lblNumberOfClients.AutoSize = true;
            this.lblNumberOfClients.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfClients.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberOfClients.Location = new System.Drawing.Point(45, 16);
            this.lblNumberOfClients.Name = "lblNumberOfClients";
            this.lblNumberOfClients.Size = new System.Drawing.Size(99, 33);
            this.lblNumberOfClients.TabIndex = 0;
            this.lblNumberOfClients.Text = "Clients";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.Clients);
            this.groupBox1.Controls.Add(this.lblNumberOfClients);
            this.groupBox1.Location = new System.Drawing.Point(39, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.Suppliers);
            this.groupBox2.Controls.Add(this.lblNumberOfSuppliers);
            this.groupBox2.Location = new System.Drawing.Point(300, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox3.Controls.Add(this.Requests);
            this.groupBox3.Controls.Add(this.lblNumberOfRequests);
            this.groupBox3.Location = new System.Drawing.Point(563, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // lblNumberOfSuppliers
            // 
            this.lblNumberOfSuppliers.AutoSize = true;
            this.lblNumberOfSuppliers.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfSuppliers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberOfSuppliers.Location = new System.Drawing.Point(49, 16);
            this.lblNumberOfSuppliers.Name = "lblNumberOfSuppliers";
            this.lblNumberOfSuppliers.Size = new System.Drawing.Size(132, 33);
            this.lblNumberOfSuppliers.TabIndex = 1;
            this.lblNumberOfSuppliers.Text = "Suppliers";
            // 
            // lblNumberOfRequests
            // 
            this.lblNumberOfRequests.AutoSize = true;
            this.lblNumberOfRequests.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRequests.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumberOfRequests.Location = new System.Drawing.Point(50, 16);
            this.lblNumberOfRequests.Name = "lblNumberOfRequests";
            this.lblNumberOfRequests.Size = new System.Drawing.Size(127, 33);
            this.lblNumberOfRequests.TabIndex = 2;
            this.lblNumberOfRequests.Text = "Requests";
            // 
            // Clients
            // 
            this.Clients.AutoSize = true;
            this.Clients.Font = new System.Drawing.Font("Bahnschrift SemiLight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clients.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Clients.Location = new System.Drawing.Point(47, 58);
            this.Clients.Name = "Clients";
            this.Clients.Size = new System.Drawing.Size(70, 23);
            this.Clients.TabIndex = 1;
            this.Clients.Text = "Clients";
            // 
            // Suppliers
            // 
            this.Suppliers.AutoSize = true;
            this.Suppliers.Font = new System.Drawing.Font("Bahnschrift SemiLight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Suppliers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Suppliers.Location = new System.Drawing.Point(51, 58);
            this.Suppliers.Name = "Suppliers";
            this.Suppliers.Size = new System.Drawing.Size(92, 23);
            this.Suppliers.TabIndex = 2;
            this.Suppliers.Text = "Suppliers";
            // 
            // Requests
            // 
            this.Requests.AutoSize = true;
            this.Requests.Font = new System.Drawing.Font("Bahnschrift SemiLight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Requests.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Requests.Location = new System.Drawing.Point(52, 58);
            this.Requests.Name = "Requests";
            this.Requests.Size = new System.Drawing.Size(89, 23);
            this.Requests.TabIndex = 3;
            this.Requests.Text = "Requests";
            // 
            // Overview
            // 
            this.Overview.AutoSize = true;
            this.Overview.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Overview.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Overview.Location = new System.Drawing.Point(33, 23);
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(128, 33);
            this.Overview.TabIndex = 2;
            this.Overview.Text = "Overview";
            // 
            // lblRequests
            // 
            this.lblRequests.AutoSize = true;
            this.lblRequests.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequests.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRequests.Location = new System.Drawing.Point(33, 184);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(202, 33);
            this.lblRequests.TabIndex = 5;
            this.lblRequests.Text = "Latest requests";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestId,
            this.Date,
            this.Client,
            this.From,
            this.To,
            this.Price,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(39, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(724, 198);
            this.dataGridView1.TabIndex = 6;
            // 
            // RequestId
            // 
            this.RequestId.DataPropertyName = "RequestId";
            this.RequestId.HeaderText = "RequestId";
            this.RequestId.Name = "RequestId";
            this.RequestId.Visible = false;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            // 
            // From
            // 
            this.From.DataPropertyName = "From";
            this.From.HeaderText = "From";
            this.From.Name = "From";
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "To";
            this.To.Name = "To";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Name";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.Overview);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberOfClients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Clients;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Suppliers;
        private System.Windows.Forms.Label lblNumberOfSuppliers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Requests;
        private System.Windows.Forms.Label lblNumberOfRequests;
        private System.Windows.Forms.Label Overview;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}