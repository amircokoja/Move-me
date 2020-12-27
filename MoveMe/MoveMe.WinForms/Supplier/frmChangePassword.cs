using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MoveMe.WinForms.Supplier
{
    public partial class frmChangePassword : Form
    {
        private readonly AuthService _authService = new AuthService();
        private int UserId;
        public frmChangePassword(int id)
        {
            InitializeComponent();
            UserId = id;
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "This field is required");
                e.Cancel = true;
            }
            else if (txtNewPassword.Text.Length < 5)
            {
                errorProvider1.SetError(txtNewPassword, "You must provide at least 5 characters for password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new PasswordChangeRequest
                {
                    ConfirmPassword = txtConfirmPassword.Text,
                    CurrentPassword = "asd",
                    NewPassword = txtNewPassword.Text,
                    IsAdmin = true
                };

                try
                {
                    await _authService.ChangePassword(UserId, request);
                    MessageBox.Show("Password successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "This field is required");
                e.Cancel = true;
            }
            else if (txtConfirmPassword.Text.Length < 5)
            {
                errorProvider1.SetError(txtConfirmPassword, "You must provide at least 5 characters for password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
    }
}
