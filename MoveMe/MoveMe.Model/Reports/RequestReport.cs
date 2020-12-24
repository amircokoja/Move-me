using System;

namespace MoveMe.Model.Reports
{
    public class RequestReport
    {
        public string Client { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public double Price { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
    }
}
