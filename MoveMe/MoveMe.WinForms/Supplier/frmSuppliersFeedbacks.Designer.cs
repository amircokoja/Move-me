namespace MoveMe.WinForms.Supplier
{
    partial class frmSuppliersFeedbacks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuppliersFeedbacks));
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbPositive = new System.Windows.Forms.GroupBox();
            this.lblPositiveCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNeutralCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNegativeCounter = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRating = new System.Windows.Forms.DataGridView();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPositive.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRating)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(51, 46);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Loading....";
            // 
            // gbPositive
            // 
            this.gbPositive.BackColor = System.Drawing.Color.LightGreen;
            this.gbPositive.Controls.Add(this.lblPositiveCounter);
            this.gbPositive.Controls.Add(this.label1);
            this.gbPositive.Location = new System.Drawing.Point(41, 119);
            this.gbPositive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPositive.Name = "gbPositive";
            this.gbPositive.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPositive.Size = new System.Drawing.Size(189, 110);
            this.gbPositive.TabIndex = 1;
            this.gbPositive.TabStop = false;
            // 
            // lblPositiveCounter
            // 
            this.lblPositiveCounter.AutoSize = true;
            this.lblPositiveCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositiveCounter.ForeColor = System.Drawing.Color.White;
            this.lblPositiveCounter.Location = new System.Drawing.Point(83, 32);
            this.lblPositiveCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPositiveCounter.Name = "lblPositiveCounter";
            this.lblPositiveCounter.Size = new System.Drawing.Size(24, 25);
            this.lblPositiveCounter.TabIndex = 2;
            this.lblPositiveCounter.Text = "0";
            this.lblPositiveCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Positive";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Controls.Add(this.lblNeutralCounter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(299, 119);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(189, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblNeutralCounter
            // 
            this.lblNeutralCounter.AutoSize = true;
            this.lblNeutralCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeutralCounter.ForeColor = System.Drawing.Color.White;
            this.lblNeutralCounter.Location = new System.Drawing.Point(83, 32);
            this.lblNeutralCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNeutralCounter.Name = "lblNeutralCounter";
            this.lblNeutralCounter.Size = new System.Drawing.Size(24, 25);
            this.lblNeutralCounter.TabIndex = 2;
            this.lblNeutralCounter.Text = "0";
            this.lblNeutralCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(57, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Neutral";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Pink;
            this.groupBox2.Controls.Add(this.lblNegativeCounter);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(551, 119);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(189, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // lblNegativeCounter
            // 
            this.lblNegativeCounter.AutoSize = true;
            this.lblNegativeCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNegativeCounter.ForeColor = System.Drawing.Color.White;
            this.lblNegativeCounter.Location = new System.Drawing.Point(83, 32);
            this.lblNegativeCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNegativeCounter.Name = "lblNegativeCounter";
            this.lblNegativeCounter.Size = new System.Drawing.Size(24, 25);
            this.lblNegativeCounter.TabIndex = 2;
            this.lblNegativeCounter.Text = "0";
            this.lblNegativeCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(57, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Negative";
            // 
            // dgvRating
            // 
            this.dgvRating.AllowUserToAddRows = false;
            this.dgvRating.AllowUserToDeleteRows = false;
            this.dgvRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRating.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Details,
            this.Description});
            this.dgvRating.Location = new System.Drawing.Point(41, 284);
            this.dgvRating.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRating.Name = "dgvRating";
            this.dgvRating.ReadOnly = true;
            this.dgvRating.RowHeadersWidth = 51;
            this.dgvRating.Size = new System.Drawing.Size(699, 370);
            this.dgvRating.TabIndex = 4;
            // 
            // Details
            // 
            this.Details.DataPropertyName = "Details";
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 6;
            this.Details.Name = "Details";
            this.Details.ReadOnly = true;
            this.Details.Width = 125;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 125;
            // 
            // frmSuppliersFeedbacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 690);
            this.Controls.Add(this.dgvRating);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPositive);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSuppliersFeedbacks";
            this.Text = "Supplier feedback";
            this.Load += new System.EventHandler(this.frmSuppliersFeedbacks_Load);
            this.gbPositive.ResumeLayout(false);
            this.gbPositive.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPositive;
        private System.Windows.Forms.Label lblPositiveCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNeutralCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNegativeCounter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}