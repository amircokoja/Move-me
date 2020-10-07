﻿using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class ClientAllSuppliersViewModel : BaseViewModel
    {
        public ICommand InitCommand { get; set; }
        private readonly AuthService _authService = new AuthService();
        public ClientAllSuppliersViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        string _companyName = string.Empty;
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }
        public ObservableCollection<User> SupplierList { get; set; } = new ObservableCollection<User>();

        public async Task Init()
        {
            var search = new Model.Requests.UserSearchReqeust
            {
                Name = CompanyName,
                RoleId = (int)RoleId.Supplier
            };


            var usersList = await _authService.GetAll(search);
            
            SupplierList.Clear();
            foreach (var user in usersList)
            {
                SupplierList.Add(user);
            }
        }
        
    }
}
