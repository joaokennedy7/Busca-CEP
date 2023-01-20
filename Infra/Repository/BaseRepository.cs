
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace AddressInfra.Repository
{
    public class BaseRepository
    {
        private readonly string _connectionstring;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        protected IDbConnection Connection => new NpgsqlConnection(_connectionstring);
    }
}