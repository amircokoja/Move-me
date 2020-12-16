using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMe.WinForms.Supplier
{
    public partial class frmAddSupplier : Form
    {
        APIService _countryService = new APIService("country");
        AuthService _authService = new AuthService();
        RegisterRequest request = new RegisterRequest();
        public frmAddSupplier()
        {
            InitializeComponent();
        }

        private async void frmAddSupplier_Load(object sender, EventArgs e)
        {
            await LoadCountryComboBox();
        }

        private async Task LoadCountryComboBox()
        {
            var result = await _countryService.GetAll<List<Model.Country>>();
            result.Insert(0, new Model.Country());
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "CountryId";
            cbCountry.DataSource = result;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.Company = txtCompany.Text;
                request.Email = txtEmail.Text;
                request.Street = txtStreet.Text;
                request.City = txtCity.Text;
                request.ZipCode = txtZipCode.Text;
                request.AdditionalAddress = txtAdditional.Text;
                request.RoleId = 3;
                request.PhoneNumber = txtPhoneNumber.Text;

                var selectedCountry = cbCountry.SelectedValue;

                if (int.TryParse(selectedCountry.ToString(), out int vrstaId))
                {
                    request.CountryId = vrstaId;
                }

                request.Password = txtPassword.Text;
                request.ConfirmPassword = txtConfirmPassword.Text;

                try
                {
                    await _authService.Register(request);
                    MessageBox.Show("Supplier successfully registred", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Control control in this.Controls)
                    {
                        Helper.ClearFormControls(control);
                    }
                }
                catch (Exception) {}
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Image = file;
                txtImage.Text = fileName;
                Image image = Image.FromFile(fileName);
                pbImage.Image = image;
            }
        }

        private void txtCompany_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompany.Text))
            {
                errorProvider.SetError(txtCompany, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCompany, null);
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }
        private void txtStreet_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                errorProvider.SetError(txtStreet, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtStreet, null);
            }
        }

        private void txtCity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                errorProvider.SetError(txtCity, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCity, null);
            }
        }

        private void txtZipCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtZipCode.Text))
            {
                errorProvider.SetError(txtZipCode, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtZipCode, null);
            }
        }
        private void cbCountry_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbCountry.SelectedIndex == -1 || cbCountry.SelectedIndex == 0)
            {
                errorProvider.SetError(cbCountry, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbCountry, null);
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "This field is required");
                e.Cancel = true;
            }
            else if (txtPassword.Text.Length < 5)
            {
                errorProvider.SetError(txtPassword, "You must provide at least 5 characters for password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider.SetError(txtConfirmPassword, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtConfirmPassword, null);
            }
        }

        private void txtPhoneNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errorProvider.SetError(txtPhoneNumber, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhoneNumber, null);
            }
        }

        private void txtImage_Validating(object sender, CancelEventArgs e)
        {
            if (request.Image == null)
            {
                errorProvider.SetError(txtImage, "Select image");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtImage, null);
            }
        }

        private void txtPhoneNumber_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtPhoneNumber.Text.Length < 5)
            {
                errorProvider.SetError(txtPhoneNumber, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhoneNumber, null);
            }
        }
    }
}
