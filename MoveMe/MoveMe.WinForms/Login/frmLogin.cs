using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WinForms.Index;
using MoveMe.WinForms.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoveMe.WinForms.Login
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("country");
        AuthService _authService = new AuthService();
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            var loginRequest = new LoginRequest
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Roles = new List<string>
                {
                    Role.Admin
                }
            };

            try
            {
                var loginResult = await _authService.Login(loginRequest);
                APIService.token = loginResult.token;

                this.Hide();
                frmIndex indexForm = new frmIndex();
                indexForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
