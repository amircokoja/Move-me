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

        string _currentPasswordError = string.Empty;
        public string CurrentPasswordError
        {
            get { return _currentPasswordError; }
            set { SetProperty(ref _currentPasswordError, value); }
        }
        bool _currentPasswordErrorVisible;
        public bool CurrentPasswordErrorVisible
        {
            get { return _currentPasswordErrorVisible; }
            set { SetProperty(ref _currentPasswordErrorVisible, value); }
        }

        bool _showMessage;
        public bool ShowMessage
        {
            get { return _showMessage; }
            set { SetProperty(ref _showMessage, value); }
        }
        string _newPasswordError = string.Empty;
        public string NewPasswordError
        {
            get { return _newPasswordError; }
            set { SetProperty(ref _newPasswordError, value); }
        }
        bool _newPasswordErrorVisible;
        public bool NewPasswordErrorVisible
        {
            get { return _newPasswordErrorVisible; }
            set { SetProperty(ref _newPasswordErrorVisible, value); }
        }

        string _confirmPasswordError = string.Empty;
        public string ConfirmPasswordError
        {
            get { return _confirmPasswordError; }
            set { SetProperty(ref _confirmPasswordError, value); }
        }
        bool _confirmPasswordErrorVisible;
        public bool ConfirmPasswordErrorVisible
        {
            get { return _confirmPasswordErrorVisible; }
            set { SetProperty(ref _confirmPasswordErrorVisible, value); }
        }
        #endregion

        private readonly AuthService _authService = new AuthService();

        public async Task ChangePassword()
        {
            if (!IsValid())
            {
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
            HideErrors();

            var valid = true;

            if (NewPassword.Length < 5 || NewPassword.Length > 40)
            {
                NewPasswordErrorVisible = true;
                NewPasswordError = Constants.ErrorMinumumLength5;
                valid = false;
            }

            if (CurrentPassword.Length < 5 || CurrentPassword.Length > 40)
            {
                CurrentPasswordErrorVisible = true;
                CurrentPasswordError = Constants.ErrorMinumumLength5;
                valid = false;
            }

            if (ConfirmPassword.Length < 5 || ConfirmPassword.Length > 40)
            {
                ConfirmPasswordErrorVisible = true;
                ConfirmPasswordError = Constants.ErrorMinumumLength5;
                valid = false;
            }

            return valid;
        }

        void HideErrors()
        {
            ConfirmPasswordErrorVisible = CurrentPasswordErrorVisible = NewPasswordErrorVisible = false;
        }
    }
}
