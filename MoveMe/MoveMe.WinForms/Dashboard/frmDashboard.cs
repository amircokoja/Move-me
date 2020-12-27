using MoveMe.Model;
using MoveMe.WinForms.Models;
using MoveMe.WinForms.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoveMe.WinForms.Dashboard
{
    public partial class frmDashboard : Form
    {
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _statusService = new APIService("status");
        private readonly AuthService _authService = new AuthService();
        public frmDashboard()
        {
            InitializeComponent();
        }

        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            var counters = await _authService.GetCounters();

            txtClients.Text = counters.NumberOfClients.ToString();
            txtSuppliers.Text = counters.NumberOfSuppliers.ToString();

            var requests = await _requestService.GetAll<List<Request>>();
            txtRequests.Text = requests.Count.ToString();

            var dashboardList = new List<DashboardRequest>();
            
            foreach (var request in requests)
            {
                var user = await _authService.GetById(request.ClientId);
                var fromAddress = await _addressService.GetById<Address>((int)user.AddressId);
                var toAddress = await _addressService.GetById<Address>(request.DeliveryAddress);
                var status = await _statusService.GetById<Status>(request.StatusId);

                var dashboardRequest = new DashboardRequest
                {
                    Client = user.FirstName + " " + user.LastName,
                    Date = request.Date,
                    From = fromAddress.City,
                    To = toAddress.City,
                    Price = request.Price.ToString() + " $",
                    Status = status.Name,
                    RequestId = request.RequestId
                };

                dashboardList.Add(dashboardRequest);
            }

            dgvRequests.DataSource = dashboardList;
        }

        private void btnRequestReport_Click(object sender, EventArgs e)
        {
            var dialog = new frmReportRequests();
            dialog.ShowDialog();
        }

        private void btnReportMostActive_Click(object sender, EventArgs e)
        {
            var dialog = new frmMostActiveUsers();
            dialog.ShowDialog();
        }

        private void dgvRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                var selected = dgvRequests.SelectedRows[0].DataBoundItem as DashboardRequest;

                var dialog = new frmRequestDetails(selected.RequestId);
                dialog.ShowDialog();
            }
        }
    }
}
