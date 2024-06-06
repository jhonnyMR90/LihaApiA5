using Dapper;
using LIhaApiA5.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIhaApiA5.Data.Repositorios
{
    public class productospvpRepository : Iproductospvp
    {
        private readonly MySqlConfiguration _connectionString;
        public productospvpRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<productospvp>> GetAllProductos()
        {
            var db = dbConnection();

            var sql = @"select * from productospvp";
            return await db.QueryAsync<productospvp>(sql, new { });
        }

        public Task<productospvp> GetDetails(string CodigoVentaProducto)
        {
            var db = dbConnection();




            var sql = @"select * from productospvp WHERE  CodigoVentaProducto like @codigo";
            return db.QueryFirstOrDefaultAsync<productospvp>(sql, new { codigo = CodigoVentaProducto });
        }
    }
}
