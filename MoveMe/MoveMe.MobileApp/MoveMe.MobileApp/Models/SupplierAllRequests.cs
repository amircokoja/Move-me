﻿using System;

namespace MoveMe.MobileApp.Models
{
    public class SupplierAllRequests
    {
        public int RequestId { get; set; }
        public string FullName { get; set; }
        public string FromCountry { get; set; }
        public string ToCountry { get; set; }
        public double Price { get; set; }
    }
}
