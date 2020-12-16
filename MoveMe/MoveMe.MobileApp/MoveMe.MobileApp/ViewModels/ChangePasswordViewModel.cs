using MoveMe.MobileApp.Services;
using System.Threading.Tasks;
using MoveMe.Model.Requests;
using MoveMe.MobileApp.Models;

namespace MoveMe.MobileApp.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        #region Properties
        int _userId;
        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }
        string _currentPassword = string.Empty;
        public string CurrentPassword
        {
            get { return _currentPassword; }
            set { SetProperty(ref _currentPassword, value); }
        }
        string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }
        string _newPassword = string.Empty;
        public string NewPassword
        {
            get { return _newPassword; }
            set { SetProperty(ref _newPassword, value); }
        }
        string _newPasswordError = string.Empty;
        public string NewPasswordError
        {
            get { return _newPasswordError; }
            set { SetProperty(ref _newPasswordError, value); }
        }
        bool _errorVisible;
        public bool ErrorVisible
        {
            get { return _errorVisible; }
            set { SetProperty(ref _errorVisible, value); }
        }

        bool _showMessage;
        public bool ShowMessage
        {
            get { return _showMessage; }
            set { SetProperty(ref _showMessage, value); }
        }
        #endregion

        private readonly AuthService _authService = new AuthService();

        public async Task ChangePassword()
        {
            ErrorVisible = !IsValid();

            if (ErrorVisible)
            {
                NewPasswordError = Constants.ErrorMinumumLength4;
                return;
            }

            UserId = int.Parse(JWTService.DecodeJWT());

            var request = new PasswordChangeRequest
            {
                ConfirmPassword = ConfirmPassword,
                CurrentPassword = CurrentPassword,
                NewPassword = NewPassword
            };

            try
            {
                await _authService.ChangePassword(UserId, request);
                ShowMessage = true;
                ClearFields();
            }
            catch
            {}
        }

        private void ClearFields()
        {
            CurrentPassword = ConfirmPassword = NewPassword = string.Empty;
        }

        private bool IsValid()
        {
            return NewPassword.Length >= 4;
        }
    }
}
