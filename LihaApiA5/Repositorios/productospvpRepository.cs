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


        public Task<IEnumerable<productospvp>> GetDetails(string CodigoVentaProducto)
        {
            var db = dbConnection();
            var sql = @"select * from productospvp WHERE  CodigoVentaProducto like @codigo";
            return db.QueryAsync<productospvp>(sql, new { codigo = CodigoVentaProducto });
        }
        
        public Task<IEnumerable<productospvp>> GetItemsTansito(string CodigoVentaProducto)
        {
            var db = dbConnection();
            var sql = @"select * from productospvp WHERE  CodigoVentaProducto like @codigo  and CantidadCompraDetalle <> 'S/N'";
            return db.QueryAsync<productospvp>(sql, new { codigo = CodigoVentaProducto });
        }
        
        public Task<IEnumerable<productospvp>> GetDetailsDescription(string DescripcionProducto)
        {
            var parametro = "%" + DescripcionProducto + "%";
            var db = dbConnection();
            var sql = @"select * from productospvp WHERE  DescripcionProducto like @codigo";
            return db.QueryAsync<productospvp>(sql, new { codigo = parametro });
        }

        public Task<IEnumerable<productospvp>> GetDetailsPalabra(string palabra)
        {
            var parametro = "%" + palabra + "";
            var db = dbConnection();
            var sql = @"select * from productospvp WHERE CodigoVentaProducto LIKE @codigo OR DescripcionProducto LIKE @codigo OR Marca LIKE @codigo";
            return db.QueryAsync<productospvp>(sql, new { codigo = parametro });
        }
        

    }
}
