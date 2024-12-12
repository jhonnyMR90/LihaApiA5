using Dapper;
using LihaApiA5.@interface;
using LihaApiA5.models;
using LIhaApiA5.Data.Repositorios;
using LIhaApiA5.Model;
using MySql.Data.MySqlClient;

namespace LihaApiA5.Repositorios
{
    public class EmpleadoRepository : Iempleado
    {
        private readonly MySqlConfiguration2 _connectionString2;
        public EmpleadoRepository(MySqlConfiguration2 connectionString2)
        {
            _connectionString2 = connectionString2;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString2.ConnectionString2);
        }

        public async Task<IEnumerable<empleadoModel>> GetAllEmpleados()
        {
            var db = dbConnection();
            var sql = @"SELECT DISTINCT CedulaEmpleado, Apellidos_Nombres_Empleado AS ApellidosNombresEmpleado, NombreUsuarioEmpleado FROM empleados WHERE empleados.PerfilesEmpleado = '100122180241769' AND RolPagoEmpleado = '1'";
            return await db.QueryAsync<empleadoModel>(sql, new { });

        }
    }
}
