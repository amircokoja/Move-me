﻿namespace MoveMe.MobileApp.Models
{
    public static class Constants
    {
        public static string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public static string EnterValidEmail = "Enter valid email";
        public static string EnterValidValue = "Enter valid value";
        public static string EnterValidCity = "Enter valid city name";
        public static string EnterValidStreet = "Enter valid street name";
        public static string EnterValidZipCode = "Enter valid zip code";
        public static string SelectCountry = "Select country";
        public static string CalculatePrice = "Calculate price before submitting";
        public static string ErrorMinumumLength4 = "Minimum password length is 4 characters";
        

        public static string Error = "Error";
        public static string UnknownError = "Unknown error ocurred";
        public static string AccountCreated = "Account created";
        public static string AccountCreatedMessage = "Account is created successfully. Please login now";
        public static string OK = "OK";

        public static string RequestCreated = "Request created";
        public static string RequestCreatedMessage = "When the supplier accepts your request, you will be notified.";
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
        Rejected
    }

    public enum RatingType
    {
        Positive = 1,
        Neutral,
        Negative
    }
}