using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DBAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters, string connectionId = "Default")
        {
            {
                using IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

                connection.Open();

                var result = await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);

                connection.Close();

                return result;

            }
        }




        public async Task SaveData<T>(string procedure, T parameters, string connectionId = "Default")
        {

            {
                using IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

                connection.Open();

                await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);

                connection.Close();

            }
        }

    }

}
