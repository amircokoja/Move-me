using AutoMapper;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace MoveMe.WebAPI.Services
{
    public class RatingService : BaseCRUDService<Model.Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest, Rating>
    {
        public RatingService(MoveMeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Rating> GetAll(RatingSearchRequest search = null)
        {
            var query = _context.Rating.AsQueryable();

            if (search?.SupplierId.HasValue == true)
            {
                query = query.Where(a => a.SupplierId == search.SupplierId);
            }

            if (search?.RequestId.HasValue == true)
            {
                query = query.Where(a => a.RequestId == search.RequestId);
            }

            var list = query.ToList();

            return _mapper.Map<IList<Model.Rating>>(list);
        }
    }
}
