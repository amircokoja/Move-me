using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {
        bool _noNotifcations;
        public bool NoNotifications
        {
            get { return _noNotifcations; }
            set { SetProperty(ref _noNotifcations, value); }
        }

        bool _showNotifications = true;
        public bool ShowNotifications
        {
            get { return _showNotifications; }
            set { SetProperty(ref _showNotifications, value); }
        }

        private readonly APIService _notificationService = new APIService("notification");
        public ICommand InitCommand { get; set; }
        public int UserId { get; set; }
        public NotificationsViewModel()
        {
            UserId = int.Parse(JWTService.DecodeJWT());
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Notification> NotificationList { get; set; } = new ObservableCollection<Notification>();
        public async Task Init()
        {
            var search = new Model.Requests.NotificationSearchRequest
            {
                UserToId = UserId
            };

            var notificationList = await _notificationService.GetAll<List<Model.Notification>>(search);

            NotificationList.Clear();
            foreach (var notification in notificationList)
            {
                var notif = new Notification
                {
                    NotificationId = notification.NotificationId,
                    Date = notification.CreatedAt,
                    ItemId = notification.ItemId,
                    Text = GenerateNotificationText(notification.NotificationTypeId),
                    NotificationTypeId = notification.NotificationTypeId,
                    UserToId = notification.UserToId
                };

                NotificationList.Add(notif);
            }

            if (NotificationList.Count == 0)
            {
                NoNotifications = true;
                ShowNotifications = false;
            }
        }


        private string GenerateNotificationText(int NotificationTypeId)
        {
            string text = string.Empty;
            switch (NotificationTypeId)
            {
                case (int)NotificationType.NewRequest:
                    text = "You have new offer for your request.";
                    break;
                case (int)NotificationType.OfferAccepted:
                    text = "Your offer is accepted.";
                    break;
                case (int)NotificationType.OfferRejected:
                    text = "Your offer is rejected.";
                    break;
                case (int)NotificationType.OfferFinished:
                    text = "You have successfully finished requst.";
                    break;
                case (int)NotificationType.Feedback:
                    text = "Client gave you feedback.";
                    break;
                default:
                    break;
            }

            return text;
        }

        public async Task DeleteNotification(int notificationId)
        {
            await _notificationService.Delete(notificationId);
        }
    }
}
