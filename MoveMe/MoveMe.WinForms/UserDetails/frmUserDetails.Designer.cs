namespace MoveMe.WinForms.UserDetails
{
    partial class frmUserDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDetails));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.cbInactive = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.textRole = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPhoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCountry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textStreet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textZipCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.textAdditionalAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.btnRating = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(11, 38);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "User role";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(196, 38);
            this.cbRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(163, 21);
            this.cbRole.TabIndex = 3;
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.cbRole_SelectedIndexChanged);
            // 
            // cbInactive
            // 
            this.cbInactive.AutoSize = true;
            this.cbInactive.Location = new System.Drawing.Point(382, 40);
            this.cbInactive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbInactive.Name = "cbInactive";
            this.cbInactive.Size = new System.Drawing.Size(104, 19);
            this.cbInactive.TabIndex = 4;
            this.cbInactive.Text = "Show inactive";
            this.cbInactive.UseVisualStyleBackColor = true;
            this.cbInactive.CheckedChanged += new System.EventHandler(this.cbInactive_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(499, 38);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 21);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FullName,
            this.Email,
            this.PhoneNumber});
            this.dgvUsers.Location = new System.Drawing.Point(10, 86);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(580, 145);
            this.dgvUsers.TabIndex = 6;
            this.dgvUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "Name";
            this.FullName.HeaderText = "Name";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "PhoneNumber";
            this.PhoneNumber.MinimumWidth = 6;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Width = 125;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(89, 85);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(92, 102);
            this.textName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(140, 20);
            this.textName.TabIndex = 8;
            // 
            // textRole
            // 
            this.textRole.Location = new System.Drawing.Point(92, 144);
            this.textRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textRole.Name = "textRole";
            this.textRole.ReadOnly = true;
            this.textRole.Size = new System.Drawing.Size(140, 20);
            this.textRole.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "User role";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(92, 187);
            this.textEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEmail.Name = "textEmail";
            this.textEmail.ReadOnly = true;
            this.textEmail.Size = new System.Drawing.Size(140, 20);
            this.textEmail.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // textPhoneNumber
            // 
            this.textPhoneNumber.Location = new System.Drawing.Point(346, 110);
            this.textPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPhoneNumber.Name = "textPhoneNumber";
            this.textPhoneNumber.ReadOnly = true;
            this.textPhoneNumber.Size = new System.Drawing.Size(140, 20);
            this.textPhoneNumber.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Phone number";
            // 
            // textCountry
            // 
            this.textCountry.Location = new System.Drawing.Point(346, 145);
            this.textCountry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCountry.Name = "textCountry";
            this.textCountry.ReadOnly = true;
            this.textCountry.Size = new System.Drawing.Size(140, 20);
            this.textCountry.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Country";
            // 
            // textCity
            // 
            this.textCity.Location = new System.Drawing.Point(346, 188);
            this.textCity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCity.Name = "textCity";
            this.textCity.ReadOnly = true;
            this.textCity.Size = new System.Drawing.Size(140, 20);
            this.textCity.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "City";
            // 
            // textStreet
            // 
            this.textStreet.Location = new System.Drawing.Point(346, 230);
            this.textStreet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textStreet.Name = "textStreet";
            this.textStreet.ReadOnly = true;
            this.textStreet.Size = new System.Drawing.Size(140, 20);
            this.textStreet.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Street";
            // 
            // textZipCode
            // 
            this.textZipCode.Location = new System.Drawing.Point(346, 275);
            this.textZipCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textZipCode.Name = "textZipCode";
            this.textZipCode.ReadOnly = true;
            this.textZipCode.Size = new System.Drawing.Size(140, 20);
            this.textZipCode.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 259);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "Zip code";
            // 
            // pbUser
            // 
            this.pbUser.Location = new System.Drawing.Point(92, 234);
            this.pbUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(106, 106);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.TabIndex = 23;
            this.pbUser.TabStop = false;
            // 
            // textAdditionalAddress
            // 
            this.textAdditionalAddress.Location = new System.Drawing.Point(346, 322);
            this.textAdditionalAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textAdditionalAddress.Name = "textAdditionalAddress";
            this.textAdditionalAddress.ReadOnly = true;
            this.textAdditionalAddress.Size = new System.Drawing.Size(140, 20);
            this.textAdditionalAddress.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 306);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Additional address";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(79, 26);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 23);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.btnRating);
            this.gbDetails.Controls.Add(this.btnDelete);
            this.gbDetails.Controls.Add(this.btnChangePassword);
            this.gbDetails.Controls.Add(this.pbUser);
            this.gbDetails.Controls.Add(this.btnEdit);
            this.gbDetails.Controls.Add(this.lblName);
            this.gbDetails.Controls.Add(this.textAdditionalAddress);
            this.gbDetails.Controls.Add(this.textName);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.label2);
            this.gbDetails.Controls.Add(this.textZipCode);
            this.gbDetails.Controls.Add(this.textRole);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.textStreet);
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.textEmail);
            this.gbDetails.Controls.Add(this.textCity);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.textPhoneNumber);
            this.gbDetails.Controls.Add(this.textCountry);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Location = new System.Drawing.Point(11, 234);
            this.gbDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbDetails.Size = new System.Drawing.Size(580, 390);
            this.gbDetails.TabIndex = 27;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "User details";
            // 
            // btnRating
            // 
            this.btnRating.Location = new System.Drawing.Point(294, 26);
            this.btnRating.Name = "btnRating";
            this.btnRating.Size = new System.Drawing.Size(121, 23);
            this.btnRating.TabIndex = 29;
            this.btnRating.Text = "See user ratings";
            this.btnRating.UseVisualStyleBackColor = true;
            this.btnRating.Click += new System.EventHandler(this.btnRating_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(430, 26);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Deactivate";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(156, 26);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(125, 23);
            this.btnChangePassword.TabIndex = 27;
            this.btnChangePassword.Text = "Change password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Name";
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 634);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbInactive);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmUserDetails";
            this.Text = "User details";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.CheckBox cbInactive;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPhoneNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textStreet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textZipCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.TextBox textAdditionalAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnRating;
    }
}