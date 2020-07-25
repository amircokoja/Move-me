using AutoMapper;
using MoveMe.WebAPI.Database;

namespace MoveMe.WebAPI.Services
{
    public class BaseCRUDService<T, TSearch, TInsert, TUpdate, TDb> : BaseService<T, TSearch, TDb>, ICRUDService<T, TSearch, TInsert, TUpdate> where TDb : class
    {
        public BaseCRUDService(MoveMeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var entity = _mapper.Map<TDb>(request);
            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDb>().Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _context.Set<TDb>().Find(id);
            _context.Set<TDb>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
