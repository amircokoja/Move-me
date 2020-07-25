using System;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Database
{
    public partial class RatingType
    {
        public RatingType()
        {
            Rating = new HashSet<Rating>();
        }

        public int RatingTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }
    }
}
