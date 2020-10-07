using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMe.WinForms.UserDetails
{
    public partial class frmUserDetails : Form
    {
        AuthService _authService = new AuthService();


        public frmUserDetails()
        {
            InitializeComponent();
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadRoleComboBox();

            await CreateRequest();
        }

        private async Task LoadRoleComboBox()
        {
            var result = await _authService.GetRoles();
            result.Insert(0, new Model.ComboBoxItem());
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
    }
}
