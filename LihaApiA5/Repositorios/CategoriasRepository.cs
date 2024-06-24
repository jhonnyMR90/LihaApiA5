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
    public class CategoriasRepository : IGRUPOCATEGORIALINEA
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
        public async Task<IEnumerable<GRUPOCATEGORIALINEA>> GetAllCategorias()
        {
            var db = dbConnection();

            var sql = @"select NombreGrupo, AbreviadoGrupo , NombreCategoria, AbreviadoCategoria,  NombreLinea, AbreviadoLinea from grupos  JOIN  categorias on categorias.CodigoCategoria = grupos.CategoriasGrupos join lineas on lineas.CodigoLinea = categorias.LineasCategorias;";
            return await db.QueryAsync<GRUPOCATEGORIALINEA>(sql, new{ });

        }

        //public  Task<categorias> GetDetails(string CodigoCategoria)
        //{
        //    var db = dbConnection();
        //
        //    var sql = @"Select CodigoCategoria, NombreCategoria, AbreviadoCategoria, IF(ActivaCategoria='0','DESACTIVADO','ACTIVADO') AS activaCategoria from categorias where CodigoCategoria= @codigo ";
        //    return db.QueryFirstOrDefaultAsync<categorias>(sql, new { codigo = CodigoCategoria });
        //}



        //
        //public Task<bool> InsertCategorias(categorias categoria)
        //{
        //    throw new NotImplementedException();
        //}
        //
        //public Task<bool> UpdateCategorias(categorias categoria)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
