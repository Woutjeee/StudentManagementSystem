using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class ClassRepository : GenericRepository<Class>, IClass
    {
        public ClassRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
