using System.Collections.Generic;

namespace MoveMe.WebAPI.Database
{
    public partial class Status
    {
        public Status()
        {
            Request = new HashSet<Request>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
