﻿using System;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public string Description { get; set; }
        public int? RequestId { get; set; }
        public int? RatingTypeId { get; set; }

        public virtual RatingType RatingType { get; set; }
        public virtual Request Request { get; set; }
    }
}
