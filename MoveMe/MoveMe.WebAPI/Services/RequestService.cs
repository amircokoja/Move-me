using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace MoveMe.WebAPI.Services
{
    public class RequestService : BaseCRUDService<Model.Request, RequestSearchRequest, RequestInsertRequest, RequestUpdateRequest, Request>
    {
        public RequestService(MoveMeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Request> GetAll(RequestSearchRequest search = null)
        {
            var query = _context.Request.AsQueryable();

            if (search?.UserId.HasValue == true)
            {
                query = query.Where(a => a.ClientId == search.UserId);
            }

            if (search?.CountryId.HasValue == true)
            {
                query = query.Where(a => a.DeliveryAddressNavigation.CountryId == search.CountryId);
            }

            if (search?.MaximumRooms.HasValue == true)
            {
                query = query.Where(a => a.Rooms <= search.MaximumRooms);
            }

            if (search?.MinimumPrice.HasValue == true)
            {
                query = query.Where(a => a.Price >= search.MinimumPrice);
            }

            if (search?.StatusId.HasValue == true)
            {
                query = query.Where(a => a.StatusId == search.StatusId);
            }

            if (search?.ShowInactive == false)
            {
                query = query.Where(a => a.Inactive == false);
            }

            var list = query.ToList();

            return _mapper.Map<IList<Model.Request>>(list);
        }
    }
}
