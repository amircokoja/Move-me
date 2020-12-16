using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class MyOffersViewModel : BaseViewModel
    {
        public ICommand InitCommand { get; set; }
        private readonly APIService _offerService = new APIService("offer");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _offerStatusService = new APIService("offerstatus");
        public MyOffersViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<MyOffers> OfferList { get; set; } = new ObservableCollection<MyOffers>();

        public async Task Init()
        {
            OfferList.Clear();

            var id = int.Parse(JWTService.DecodeJWT());
            var search = new Model.Requests.OfferSearchRequest
            {
                UserId = id
            };

            var offerList = await _offerService.GetAll<List<Offer>>(search);

            OfferList.Clear();

            foreach (var item in offerList)
            {
                var request = await _requestService.GetById<Request>(item.RequestId);
                var address = await _addressService.GetById<Address>(request.DeliveryAddress);
                var status = await _offerStatusService.GetById<Model.OfferStatus>(item.OfferStatusId);

                var offer = new MyOffers
                {
                    Address = address.City,
                    IsActive = item.OfferStatusId == (int)Models.OfferStatus.Active,
                    IsRejected = item.OfferStatusId == (int)Models.OfferStatus.Rejected,
                    IsAccepted = item.OfferStatusId == (int)Models.OfferStatus.Accepted,
                    IsFinished = item.OfferStatusId == (int)Models.OfferStatus.Finished,
                    OfferId = item.OfferId,
                    Price = request.Price,
                    RequestId = item.RequestId,
                    OfferStatus = status.Name
                };

                OfferList.Add(offer);
            }
        }
    }
}
