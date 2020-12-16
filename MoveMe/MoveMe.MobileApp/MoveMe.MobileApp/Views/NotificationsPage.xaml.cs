using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        NotificationsViewModel model = null;
        public NotificationsPage()
        {
            InitializeComponent();
            BindingContext = model = new NotificationsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var notification = e.SelectedItem as Notification;

            switch (notification.NotificationTypeId)
            {
                case (int)NotificationType.NewRequest:
                case (int)NotificationType.OfferAccepted:
                case (int)NotificationType.OfferRejected:
                case (int)NotificationType.OfferFinished:
                    await Navigation.PushAsync(new ClientRequestDetailsPage(notification.ItemId));
                    break;
                case (int)NotificationType.Feedback:
                    await Navigation.PushAsync(new FeedbackPage(notification.UserToId));
                    break;
                default:
                    break;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var notification = button.BindingContext as Notification;
            await model.DeleteNotification(notification.NotificationId);
            await model.Init();
        }
    }
}