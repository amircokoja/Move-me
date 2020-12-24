namespace MoveMe.Model.Requests
{
    public class PasswordChangeRequest
    {
        public string CurrentPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
        public bool? IsAdmin { get; set; }
    }
}