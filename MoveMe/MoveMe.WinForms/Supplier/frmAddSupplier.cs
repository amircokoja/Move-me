using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMe.WinForms.Supplier
{
    public partial class frmAddSupplier : Form
    {
        readonly APIService _addressService = new APIService("address");
        readonly APIService _countryService = new APIService("country");
        readonly AuthService _authService = new AuthService();
        readonly RegisterRequest request = new RegisterRequest();
        private User _user;
        private Address _address;
        private bool _editMode = false;
        private bool _imageChanged = false;
        public frmAddSupplier(User user)
        {
            InitializeComponent();
            if (user != null)
            {
                _user = user;
                _editMode = true;
                txtPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                lblPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                gbPassword.Visible = false;
            }
        }

        private async void frmAddSupplier_Load(object sender, EventArgs e)
        {
            await LoadCountryComboBox();

            if (_editMode)
            {
                txtCompany.Text = _user.Company;
                txtEmail.Text = _user.Email;
                txtPhoneNumber.Text = _user.PhoneNumber;
                _address = await _addressService.GetById<Address>((int)_user.AddressId);
                txtCity.Text = _address.City;
                txtStreet.Text = _address.Street;
                txtZipCode.Text = _address.ZipCode;
                txtAdditional.Text = _address.AdditionalAddress;
                cbCountry.SelectedValue = _address.CountryId;
                pbImage.Image = Helper.ByteToImage(_user.Image);
            }
        }

        private async Task LoadCountryComboBox()
        {
            var result = await _countryService.GetAll<List<Country>>();
            result.Insert(0, new Country());
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "CountryId";
            cbCountry.DataSource = result;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_editMode)
                {
                    var addressRequest = new AddressUpsertRequest
                    {
                        AdditionalAddress = txtAdditional.Text,
                        City = txtCity.Text,
                        Street = txtStreet.Text,
                        ZipCode = txtZipCode.Text
                    };

                    var selectedCountry = cbCountry.SelectedValue;

                    if (int.TryParse(selectedCountry.ToString(), out int vrstaId))
                    {
                        addressRequest.CountryId = vrstaId;
                    }

                    await _addressService.Update<Address>(_address.AddressId, addressRequest);

                    var newRequest = new UserUpdateRequest
                    {
                        Company = txtCompany.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    };

                    if (_imageChanged)
                    {
                        newRequest.Image = Helper.ImageToByte(pbImage.Image);
                    }

                    try
                    {
                        await _authService.Update(_user.Id, newRequest);
                        MessageBox.Show("User successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (Control control in this.Controls)
                        {
                            Helper.ClearFormControls(control);
                        }
                    }
                    catch (Exception) {}
                }
                else
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
                    catch (Exception) { }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _imageChanged = true;
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
            else if (txtCompany.Text.Length < 3)
            {
                errorProvider.SetError(txtCompany, "Minimum length is 3 characters");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCompany, null);
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
           
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "This field is required");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtEmail.Text, EmailRegex, RegexOptions.IgnoreCase))
            {
                errorProvider.SetError(txtEmail, "Enter valid email.");
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
            else if (txtStreet.Text.Length < 3)
            {
                errorProvider.SetError(txtStreet, "Minimum length is 3 characters");
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
            else if (txtCity.Text.Length < 3)
            {
                errorProvider.SetError(txtCity, "Minimum length is 3 characters");
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
            else if (txtZipCode.Text.Length < 4)
            {
                errorProvider.SetError(txtZipCode, "Minimum length is 4 characters");
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
            if (string.IsNullOrWhiteSpace(txtPassword.Text) && !_editMode)
            {
                errorProvider.SetError(txtPassword, "This field is required");
                e.Cancel = true;
            }
            else if (txtPassword.Text.Length < 5 && !_editMode)
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
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text) && !_editMode)
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
            else if (txtPhoneNumber.Text.Length < 8)
            {
                errorProvider.SetError(txtPhoneNumber, "Minimum length is 8 characters");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhoneNumber, null);
            }
        }

        private void txtImage_Validating(object sender, CancelEventArgs e)
        {
            if (request.Image == null && !_editMode)
            {
                errorProvider.SetError(txtImage, "Select image");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtImage, null);
            }
        }

        private void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtZipCode.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtZipCode.Text = txtZipCode.Text.Remove(txtZipCode.Text.Length - 1);
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPhoneNumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtPhoneNumber.Text = txtPhoneNumber.Text.Remove(txtPhoneNumber.Text.Length - 1);
            }
        }
    }
}
