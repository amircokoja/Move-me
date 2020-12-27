namespace MoveMe.MobileApp.Models
{
    public static class Constants
    {
        public static string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public static string EnterValidEmail = "Enter valid email";
        public static string EnterValidCredentials = "Enter valid credentials";
        public static string EnterValidValue = "Enter valid value";
        public static string EnterValidCity = "Enter valid city name";
        public static string EnterValidStreet = "Enter valid street name";
        public static string EnterValidZipCode = "Enter valid zip code";
        public static string SelectFeedback = "Select feedback type";
        public static string SelectCountry = "Select country";
        public static string CalculatePrice = "Enter required data to submit form";
        public static string ErrorMinumumLength4 = "Minimum password length is 4 characters";
        public static string ErrorMinumumLength5 = "Minimum password length is 5 characters";
        public static string TooLong = "Too long";
        public static string MaximumRooms = "Maximum number of rooms is 20";
        

        public static string Error = "Error";
        public static string UnknownError = "Unknown error ocurred";
        public static string AccountCreated = "Account created";
        public static string AccountCreatedMessage = "Account is created successfully. Please login now";
        public static string OK = "OK";

        public static string RequestCreated = "Request saved successfully";
        public static string RequestCreatedMessage = "When supplier accepts your request, you will be notified.";
        public static string RequestUpdated = "Success";
        public static string RequestUpdatedMessage = "Request updated successfully.";

        public static string Saved = "Saved";
        public static string SavedMessage = "Data saved successfully";

        public static string PasswordUpdated = "Password updated";
        public static string PasswordUpdatedMessage = "Your password has been changed successfully";
    }

    public enum Status
    {
        Pending = 1,
        Accepted,
        Finished
    }

    public enum OfferStatus
    {
        Active = 1,
        Accepted,
        Rejected,
        Finished
    }

    public enum RatingType
    {
        Positive = 1,
        Neutral,
        Negative
    }

    public enum NotificationType
    {
        NewRequest = 1,
        OfferAccepted,
        OfferRejected,
        OfferFinished,
        Feedback
    }
}
