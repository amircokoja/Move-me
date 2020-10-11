using System;

namespace MoveMe.MobileApp.Models
{
    public class ProfileOptions
    {
        public ProfileOptionsValue Value { get; set; }
        public string Name { get; set; }
    }

    public enum ProfileOptionsValue
    {
        BasicInformation = 1,
        Address,
        Password
    }
}
