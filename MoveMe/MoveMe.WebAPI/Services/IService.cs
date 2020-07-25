using System.Collections.Generic;

namespace MoveMe.WebAPI.Services
{
    public interface IService<T, TSearch>
    {
        IList<T> GetAll(TSearch search = default);
        T GetById(int id);
    }
}
