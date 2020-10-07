using System;

namespace MoveMe.MobileApp.Models
{
    public class ClientDashboardRequest
    {
        public int RequestId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
    }
}
