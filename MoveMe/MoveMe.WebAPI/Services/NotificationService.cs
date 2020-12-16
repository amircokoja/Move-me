using AutoMapper;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace MoveMe.WebAPI.Services
{
    public class NotificationService : BaseCRUDService<Model.Notification, NotificationSearchRequest, NotificationInsertRequest, NotificationUpdateRequest, Database.Notification>
    {
        public NotificationService(MoveMeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Notification> GetAll(NotificationSearchRequest search = null)
        {
            var query = _context.Notification.AsQueryable();

            if (search?.NotificationTypeId.HasValue == true)
            {
                query = query.Where(a => a.NotificationTypeId == search.NotificationTypeId);
            }

            if (search?.UserFromId.HasValue == true)
            {
                query = query.Where(a => a.UserFromId == search.UserFromId);
            }

            if (search?.UserToId.HasValue == true)
            {
                query = query.Where(a => a.UserToId == search.UserToId);
            }

            var list = query.ToList();

            return _mapper.Map<IList<Model.Notification>>(list);
        }
    }
}
