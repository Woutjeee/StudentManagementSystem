using System.Data;

namespace API.Interfaces
{
    public interface IDatabaseService
    {
        public bool CreateConnection();
        public string ReturnConnectionString();
    }
}
