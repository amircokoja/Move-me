using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using MoveMe.WinForms.Supplier;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMe.WinForms.UserDetails
{
    public partial class frmUserDetails : Form
    {
        AuthService _authService = new AuthService();
        APIService _addressService = new APIService("address");
        APIService _countryService = new APIService("country");
        private RoleModel _selectedRole;
        private User _selectedUser;
        public frmUserDetails()
        {
            InitializeComponent();
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadRoleComboBox();
            gbDetails.Visible = false;
            await CreateRequest();
        }

        private async Task LoadRoleComboBox()
        {
            var result = await _authService.GetRoles();
            result.Insert(0, new ComboBoxItem());
            cbRole.DisplayMember = "Text";
            cbRole.ValueMember = "Value";
            cbRole.DataSource = result;
        }

        private async void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CreateRequest();
        }

        private async void cbInactive_CheckedChanged(object sender, EventArgs e)
        {
            await CreateRequest();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await CreateRequest();
        }

        private async Task CreateRequest()
        {
            var request = new UserSearchReqeust
            {
                ShowInactive = cbInactive.Checked,
                Name = txtName.Text
            };
            if (cbRole.SelectedIndex != -1 && cbRole.SelectedIndex != 0)
            {
                var selectedRole = cbRole.SelectedValue;

                if (int.TryParse(selectedRole.ToString(), out int roleId))
                {
                    request.RoleId = roleId;
                }
            }

            var result = await _authService.GetUsers(request);
            var dgvData = new List<Model.UserDataGridView>();
            foreach (var item in result)
            {
                var data = new Model.UserDataGridView
                {
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id
                };

                if (!string.IsNullOrWhiteSpace(item?.Company))
                {
                    data.Name = item.Company;
                }
                else
                {
                    data.Name = item.FirstName + " " + item.LastName;
                }

                dgvData.Add(data);
            }
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = dgvData;
        }

        private async void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (dgvUsers.SelectedRows.Count > 0)
            {
                var selected = dgvUsers.SelectedRows[0].DataBoundItem as UserDataGridView;
                _selectedUser = await _authService.GetById(selected.Id);
                var address = await _addressService.GetById<Address>((int)_selectedUser.AddressId);
                var country = await _countryService.GetById<Country>((int)address.CountryId);

                _selectedRole = await _authService.GetRole(_selectedUser.Id);

                if (address.AdditionalAddress == null || address.AdditionalAddress == "")
                {
                    textAdditionalAddress.Text = "No additional address";
                }
                else
                {
                    textAdditionalAddress.Text = address.AdditionalAddress;
                }
                textCity.Text = address.City;
                textStreet.Text = address.Street;
                textZipCode.Text = address.ZipCode;
                textCountry.Text = country.Name;
                textEmail.Text = _selectedUser.Email;
                textRole.Text = _selectedRole.Role;
                textPhoneNumber.Text = _selectedUser.PhoneNumber;
                if (textRole.Text == "Supplier")
                {
                    pbUser.Visible = true;
                    textName.Text = _selectedUser.Company;
                    pbUser.Image = Helper.ByteToImage(_selectedUser.Image);
                }
                else
                {
                    textName.Text = _selectedUser.FirstName + " " + _selectedUser.LastName;
                    pbUser.Visible = false;
                }

                if (_selectedUser.Active)
                {
                    btnDelete.Text = "Deactivate";
                }
                else
                {
                    btnDelete.Text = "Activate";
                }

                gbDetails.Visible = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedRole != null)
            {
                if (_selectedRole.Role == Role.Supplier)
                {
                    var form = new frmAddSupplier(_selectedUser);
                    form.MdiParent = this.ParentForm;
                    form.Show();
                }
                else
                {
                    MessageBox.Show("You cannot edit client profile", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var dialog = new frmChangePassword(_selectedUser.Id);
            dialog.ShowDialog();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var result = await _authService.Deactivate(_selectedUser.Id);
            string text;
            if(result.Active)
            {
                text = "User successfully activated";
                btnDelete.Text = "Deactivate";
            }
            else
            {
                text = "User successfully deactivated";
                btnDelete.Text = "Activate";
            }
            MessageBox.Show(text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRating_Click(object sender, EventArgs e)
        {
            if (_selectedRole != null)
            {
                if (_selectedRole.Role == Role.Supplier)
                {
                    var dialog = new frmSuppliersFeedbacks(_selectedUser.Id);
                    dialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Only supplier profiles have ratings", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
