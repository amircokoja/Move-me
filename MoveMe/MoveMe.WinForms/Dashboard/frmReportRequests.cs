using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WinForms.Models;
using MoveMe.WinForms.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoveMe.WinForms.Dashboard
{
    public partial class frmReportRequests : Form
    {
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _offerService = new APIService("offer");
        private readonly AuthService _authService = new AuthService();
        public frmReportRequests()
        {
            InitializeComponent();
        }

        private async void frmReportRequests_Load(object sender, EventArgs e)
        {
            var searchRequest = new RequestSearchRequest
            {
                StatusId = (int)EStatus.Finished
            };

            var requestList = await _requestService.GetAll<List<Request>>(searchRequest);
            var sourceList = new List<RequestReport>();

            foreach (var request in requestList)
            {
                var client = await _authService.GetById(request.ClientId);
                var clientAddress = await _addressService.GetById<Address>((int)client.AddressId);
                var requestAddress = await _addressService.GetById<Address>(request.DeliveryAddress);

                var offerRequest = new OfferSearchRequest
                {
                    OfferStatusId = (int)EOfferStatus.Finished,
                    RequestId = request.RequestId
                };

                var finishedOffer = await _offerService.GetAll<List<Offer>>(offerRequest);
                var companyId = finishedOffer[0].UserId;
                var company = await _authService.GetById(companyId);
                var requestRow = new RequestReport
                {
                    Client = $"{client.FirstName} {client.LastName}",
                    AddressFrom = clientAddress.City,
                    AddressTo = requestAddress.City,
                    Company = company.Company,
                    Date = request.Date,
                    Price = $"{request.Price} $"
                };

                sourceList.Add(requestRow);
            }

            RequestReportBindingSource.DataSource = sourceList;

            this.rvRequests.RefreshReport();
        }
    }
}
