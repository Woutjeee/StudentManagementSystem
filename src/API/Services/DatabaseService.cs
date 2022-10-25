using API.Interfaces;
using API.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IOptions<ApplicationOptions> options)
        {
            _connectionString = $"Server={options.Value.Sql.Host}, {options.Value.Sql.Port}; Database={options.Value.Sql.Database}; User Id={options.Value.Sql.User}; Password={options.Value.Sql.Password}";
        }

        public bool CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);

            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public string ReturnConnectionString()
        {
            return _connectionString;
        }
    }
}
