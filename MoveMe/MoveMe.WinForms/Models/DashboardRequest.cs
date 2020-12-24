using System;

namespace MoveMe.WinForms.Models
{
    public class DashboardRequest
    {
        public int RequestId { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
    }
}
