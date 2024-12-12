using Dapper;
using LihaApiA5.@interface;
using LihaApiA5.models;
using LIhaApiA5.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIhaApiA5.Data.Repositorios
{
    public class ClienteVendedorRepository : IClienteVendedor
    {
        private readonly MySqlConfiguration2 _connectionString2;
        public ClienteVendedorRepository(MySqlConfiguration2 connectionString2)
        {
            _connectionString2 = connectionString2;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString2.ConnectionString2);
        }

        public Task<IEnumerable<ClienteVendedorModel>> GetCliente(string NombreUsuarioEmpleado, string NombreApellidoNombreComercial)
        {
            var parametro = "%" + NombreApellidoNombreComercial + "%";
            var usuario = NombreUsuarioEmpleado;
            var db = dbConnection();
            var sql = @"SELECT DISTINCT clientes_vendedores.Codigo_cliente, empleados.NombreUsuarioEmpleado, CONCAT( clientes.ApellidoCliente, ' ', clientes.NombreCliente, '/', clientes.NombreComercialCliente ) AS NombreApellidoNombreComercial,NumeroIdentificacionCliente FROM clientes_vendedores INNER JOIN empleados ON Codigo_Vendedor = CodigoEmpleado INNER JOIN clientes ON clientes_vendedores.Codigo_cliente = clientes.CodigoCliente WHERE empleados.PerfilesEmpleado = '100122180241769' AND empleados.RolPagoEmpleado <> '0' AND NombreUsuarioEmpleado = @empleado HAVING NombreApellidoNombreComercial LIKE @codigo";
            return db.QueryAsync<ClienteVendedorModel>(sql, new { codigo = parametro, empleado = usuario });
        }
    }
}
