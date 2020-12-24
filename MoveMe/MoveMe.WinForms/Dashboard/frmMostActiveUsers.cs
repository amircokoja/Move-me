using MoveMe.Model;
using MoveMe.Model.Reports;
using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MoveMe.WinForms.Dashboard
{
    public partial class frmMostActiveUsers : Form
    {
        private readonly AuthService _authService = new AuthService();
        private readonly APIService _offerService = new APIService("offer");
        private readonly APIService _requestService = new APIService("request");
        public frmMostActiveUsers()
        {
            InitializeComponent();
        }

        private async void frmMostActiveUsers_Load(object sender, System.EventArgs e)
        {
            var suppliersReport = new List<SupplierReport>();
            var clientReport = new List<ClientReport>();

            var userSearchRequest = new UserSearchReqeust
            {
                RoleId = (int)RoleId.Client
            };
            var clients = await _authService.GetUsers(userSearchRequest);

            userSearchRequest.RoleId = (int)RoleId.Supplier;
            var suppliers = await _authService.GetUsers(userSearchRequest);

            foreach (var client in clients)
            {
                var requestSearchRequest = new RequestSearchRequest
                {
                    StatusId = (int)EStatus.Finished,
                    UserId = client.Id
                };

                var numberOfFinishedRequests = (await _requestService.GetAll<List<Offer>>(requestSearchRequest)).Count;

                clientReport.Add(new ClientReport
                {
                    Client = $"{client.FirstName} {client.LastName}",
                    NumberOfFinishedRequests = numberOfFinishedRequests
                });
            }

            foreach (var supplier in suppliers)
            {
                var offerRequest = new OfferSearchRequest
                {
                    OfferStatusId = (int)EOfferStatus.Finished,
                    UserId = supplier.Id
                };

                var numberOfFinishedOffers = (await _offerService.GetAll<List<Offer>>(offerRequest)).Count;

                suppliersReport.Add(new SupplierReport
                {
                    Company = supplier.Company,
                    NumberOfFinishedRequests = numberOfFinishedOffers
                });
            }

            ClientReportBindingSource.DataSource = clientReport.OrderByDescending(a => a.NumberOfFinishedRequests).ToList();
            SupplierReportBindingSource.DataSource = suppliersReport.OrderByDescending(a => a.NumberOfFinishedRequests).ToList();

            this.rvMostActive.RefreshReport();
        }
    }
}
