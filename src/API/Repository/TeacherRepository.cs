using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacher
    {
        public TeacherRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
