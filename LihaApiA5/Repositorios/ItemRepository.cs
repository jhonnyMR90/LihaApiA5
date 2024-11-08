using Dapper;
using LihaApiA5.@interface;
using LIhaApiA5.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIhaApiA5.Data.Repositorios
{
    public class ItemRepository : IItem
    {
        private readonly MySqlConfiguration _connectionString;

        public ItemRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<itemModel>> GetAllItem()
        {
            var db = dbConnection();

            var sql = @"select DISTINCT CodigoVentaProducto, DescripcionProducto,Marca,Grupo,categoria,linea,tipoproducto,division from productospvp";
            return await db.QueryAsync<itemModel>(sql, new{ });

        }
    }
}
