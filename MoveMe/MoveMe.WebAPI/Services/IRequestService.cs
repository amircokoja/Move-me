using System.Collections.Generic;

namespace MoveMe.WebAPI.Services
{
    public interface IRequestService : ICRUDService<Model.Request, Model.Requests.RequestSearchRequest, Model.Requests.RequestInsertRequest, Model.Requests.RequestUpdateRequest>
    {
        List<Model.Request> Recommend(int id);
    }
}
