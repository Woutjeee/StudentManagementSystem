using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly DbSet<T> _entity;
        private readonly DatabaseContext _dbContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
            _entity = databaseContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(Guid id)
        {
            var x = _entity.Find(id);
            if (x is not null)
                return x;
            return null;
        }

        public virtual T Create(T type)
        {
            _entity.Add(type);
            _dbContext.SaveChanges();
            return type;
        }

        public T Update(T type)
        {
            _dbContext.Entry(type).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return type;
        }

        public T Delete(T type)
        {
            _entity.Remove(type);
            _dbContext.SaveChanges();
            return type;
        }

        public bool Exisits(Guid id)
        {
            var x = _entity.Find(id);
            if (x is null)
                return false;
            return true;
        }
    }
}
