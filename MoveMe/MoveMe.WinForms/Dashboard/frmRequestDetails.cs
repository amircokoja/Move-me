using MoveMe.Model;
using MoveMe.WinForms.Services;
using System.Windows.Forms;

namespace MoveMe.WinForms.Dashboard
{
    public partial class frmRequestDetails : Form
    {
        private readonly int _requestId;
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");
        private readonly APIService _statusService = new APIService("status");
        private readonly AuthService _authService = new AuthService();
        public frmRequestDetails(int id)
        {
            InitializeComponent();
            _requestId = id;
        }

        private async void frmRequestDetails_Load(object sender, System.EventArgs e)
        {
            var request = await _requestService.GetById<Request>(_requestId);
            var requestAddress = await _addressService.GetById<Address>(request.DeliveryAddress);
            var requestCountry = await _countryService.GetById<Country>((int)requestAddress.CountryId);
            var requestStatus = await _statusService.GetById<Status>(request.StatusId);
            var owner = await _authService.GetById(request.ClientId);
            var ownerAddress = await _addressService.GetById<Address>((int)owner.AddressId);
            var ownerCountry = await _countryService.GetById<Country>((int)ownerAddress.CountryId);

            lblAddress.Text = $"{requestCountry.Name} {requestAddress.ZipCode} {requestAddress.City} {requestAddress.Street}";
            lblPrice.Text = request.Price.ToString() + " $";
            lblStatus.Text = requestStatus.Name;
            lblDate.Text = request.Date.ToString("MM/dd/yyyy");
            lblTransport.Text = $"{request.TransportDistanceApprox} km";
            lblWeight.Text = $"{request.TotalWeightApprox} kg";
            lblRooms.Text = request.Rooms.ToString();
            
            if (request.AdditionalInformation == null || request.AdditionalInformation == "")
            {
                lblAdditionalInfo.Text = "No additional information";
            }
            else
            {
                lblAdditionalInfo.Text = request.AdditionalInformation;
            }


            lblName.Text = $"{owner.FirstName} {owner.LastName}";
            lblEmail.Text = owner.Email;
            lblTelephone.Text = owner.PhoneNumber;
            lblOwnerAddress.Text = $"{ownerCountry.Name} {ownerAddress.ZipCode} {ownerAddress.City} {ownerAddress.Street}";
        }
    }
}
