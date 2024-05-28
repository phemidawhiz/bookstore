using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BookStore.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("BookStoredb"));
            /*using var cmd = new NpgsqlCommand();
            cmd.Connection = (NpgsqlConnection?)_db;
            cmd.CommandText = "CREATE TABLE public.book (id SERIAL PRIMARY KEY," +
            "title VARCHAR(255)," +
            "genre VARCHAR(100)," +
            "isbn VARCHAR(15)," +
            "author VARCHAR(100)," +
            "year VARCHAR(4))";
            cmd.ExecuteNonQueryAsync();*/
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }
    }
}
