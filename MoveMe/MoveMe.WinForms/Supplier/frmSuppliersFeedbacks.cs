using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WinForms.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MoveMe.WinForms.Supplier
{
    public partial class frmSuppliersFeedbacks : Form
    {
        private readonly int _userId;
        private readonly AuthService _authService = new AuthService();
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _ratingService = new APIService("rating");
        private readonly List<Models.Rating> RatingList = new List<Models.Rating>();
        public frmSuppliersFeedbacks(int id)
        {
            InitializeComponent();
            _userId = id;
            dgvRating.AutoGenerateColumns = false;
        }

        private async void frmSuppliersFeedbacks_Load(object sender, System.EventArgs e)
        {
            var user = await _authService.GetById(_userId);
            lblTitle.Text = "Feedbacks for " + user.Company;

            var ratingRequest = new RatingSearchRequest
            {
                SupplierId = _userId
            };

            var ratingList = await _ratingService.GetAll<List<Rating>>(ratingRequest);

            foreach (var rating in ratingList)
            {
                var request = await _requestService.GetById<Request>((int)rating.RequestId);
                var ratingGivenBy = await _authService.GetById(request.ClientId);

                var newRatingModel = new Models.Rating
                {
                    Description = rating.Description,
                    RatingTypeId = (int)rating.RatingTypeId
                };

                string ratingType;
                if (rating.RatingTypeId == (int)ERatingType.Positive)
                {
                    ratingType = "Postive";
                }
                else if (rating.RatingTypeId == (int)ERatingType.Negative)
                {
                    ratingType = "Negative";
                }
                else
                {
                    ratingType = "Neutral";
                }

                newRatingModel.Details = $"{ratingType} feedback from " + ratingGivenBy.FirstName + " " + ratingGivenBy.LastName;

                RatingList.Add(newRatingModel);
            }

            InitCounters();
            dgvRating.DataSource = RatingList;
        }

        private void InitCounters()
        {
            lblPositiveCounter.Text = RatingList.Count(a => a.RatingTypeId == (int)ERatingType.Positive).ToString();
            lblNeutralCounter.Text = RatingList.Count(a => a.RatingTypeId == (int)ERatingType.Neutral).ToString();
            lblNegativeCounter.Text = RatingList.Count(a => a.RatingTypeId == (int)ERatingType.Negative).ToString();
        }
    }
}
