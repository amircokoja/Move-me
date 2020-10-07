namespace MoveMe.MobileApp.ViewModels
{
    public class MenuViewModel: BaseViewModel
    {
        string _selectedMenuItem;
        public string SelectedMenuItem
        {
            get
            {
                return _selectedMenuItem;
            }

            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged("SelectedMenuItem");
            }
        }
    }
}
