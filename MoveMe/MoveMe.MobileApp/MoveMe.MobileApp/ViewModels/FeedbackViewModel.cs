using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class FeedbackViewModel : BaseViewModel
    {
        int _userId;
        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }

        int _positiveRatings = 0;
        public int PositiveRatings
        {
            get { return _positiveRatings; }
            set { SetProperty(ref _positiveRatings, value); }
        }

        int _neutralRatings = 0;
        public int NeutralRatings
        {
            get { return _neutralRatings; }
            set { SetProperty(ref _neutralRatings, value); }
        }

        int _negativeRatings = 0;
        public int NegativeRatings
        {
            get { return _negativeRatings; }
            set { SetProperty(ref _negativeRatings, value); }
        }

        bool _showEmptyMessage = false;
        public bool ShowEmptyMessage
        {
            get { return _showEmptyMessage; }
            set { SetProperty(ref _showEmptyMessage, value); }
        }
        bool _showList = false;
        public bool ShowList
        {
            get { return _showList; }
            set { SetProperty(ref _showList, value); }
        }

        public ICommand InitCommand { get; set; }
        public ObservableCollection<UserRating> RatingList { get; set; } = new ObservableCollection<UserRating>();
        private readonly APIService _ratingService = new APIService("rating");
        private readonly APIService _requestService = new APIService("request");
        private readonly AuthService _authService = new AuthService();

        public FeedbackViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            var request = new RatingSearchRequest
            {
                SupplierId = UserId
            };
            var ratingList = await _ratingService.GetAll<List<Rating>>(request);

            RatingList.Clear();
            foreach (var item in ratingList)
            {
                var rating = new UserRating
                {
                    Description = item.Description,
                    RatingId = item.RatingId,
                    RatingTypeId = (int)item.RatingTypeId,
                    UserFrom = await GetUser((int)item.RequestId)
                };

                if (item.RatingTypeId == (int)Models.RatingType.Positive)
                {
                    rating.Text = "Positive feedback from " + rating.UserFrom;
                }
                else if (item.RatingTypeId == (int)Models.RatingType.Negative)
                {
                    rating.Text = "Negative feedback from " + rating.UserFrom;
                }
                else
                {
                    rating.Text = "Neutral feedback from " + rating.UserFrom;
                }

                RatingList.Add(rating);
            }

            if (ratingList.Count == 0)
            {
                ShowEmptyMessage = true;
            } 
            else
            {
                ShowList = true;
            }

            InitCounters();
        }

        private void InitCounters()
        {
            PositiveRatings = RatingList.Count(a => a.RatingTypeId == (int)Models.RatingType.Positive);
            NeutralRatings = RatingList.Count(a => a.RatingTypeId == (int)Models.RatingType.Neutral);
            NegativeRatings = RatingList.Count(a => a.RatingTypeId == (int)Models.RatingType.Negative);
        }

        private async Task<string> GetUser(int requestId)
        {
            var request = await _requestService.GetById<Request>(requestId);
            var user = await _authService.GetById(request.ClientId);

            return user.FirstName + " " + user.LastName;
        }
    }
}
