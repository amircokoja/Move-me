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
    public class ProfileViewModel : BaseViewModel
    {
        public ObservableCollection<ProfileOptions> PageOptions { get; set; } = new ObservableCollection<ProfileOptions>
        {
            new ProfileOptions { Value = ProfileOptionsValue.BasicInformation, Name = "Basic information" },
            new ProfileOptions { Value = ProfileOptionsValue.Address, Name = "Address" },
            new ProfileOptions { Value = ProfileOptionsValue.Password, Name = "Password" }
        };
    }
}
