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
    public class CategoriasRepository : Icategorias
    {
        private readonly MySqlConfiguration _connectionString;

        public CategoriasRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<categorias>> GetAllCategorias()
        {
            var db = dbConnection();

            var sql = @"Select CodigoCategoria, NombreCategoria, AbreviadoCategoria, IF(ActivaCategoria='0','DESACTIVADO','ACTIVADO') AS activaCategoria from categorias";
            return await db.QueryAsync<categorias>(sql, new{ });

        }

        public  Task<categorias> GetDetails(string CodigoCategoria)
        {
            var db = dbConnection();

            var sql = @"Select CodigoCategoria, NombreCategoria, AbreviadoCategoria, IF(ActivaCategoria='0','DESACTIVADO','ACTIVADO') AS activaCategoria from categorias where CodigoCategoria= @codigo ";
            return db.QueryFirstOrDefaultAsync<categorias>(sql, new { codigo = CodigoCategoria });
        }

        public Task<bool> InsertCategorias(categorias categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategorias(categorias categoria)
        {
            throw new NotImplementedException();
        }
    }
}
