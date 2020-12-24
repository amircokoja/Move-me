using System;

namespace MoveMe.WinForms.Models
{
    public class RequestReport
    {
        public string Client { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public string Price { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
    }
}
