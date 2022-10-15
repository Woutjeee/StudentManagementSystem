using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class StudentRepository : GenericRepository<User>, IStudent
    {
        public StudentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
