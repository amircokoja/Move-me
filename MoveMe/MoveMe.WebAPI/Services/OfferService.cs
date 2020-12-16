using AutoMapper;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace MoveMe.WebAPI.Services
{
    public class OfferService : BaseCRUDService<Model.Offer, OfferSearchRequest, OfferInsertRequest, OfferUpdateRequest, Offer>
    {
        public OfferService(MoveMeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Offer> GetAll(OfferSearchRequest search = null)
        {
            var query = _context.Offer.AsQueryable();

            if (search?.UserId.HasValue == true)
            {
                query = query.Where(a => a.UserId == search.UserId);
            }

            if (search?.RequestId.HasValue == true)
            {
                query = query.Where(a => a.RequestId == search.RequestId);
            }

            if (search?.OfferStatusId.HasValue == true)
            {
                query = query.Where(a => a.OfferStatusId == search.OfferStatusId);
            }

            var list = query.ToList();

            return _mapper.Map<IList<Model.Offer>>(list);
        }
    }
}
