using Dapper;
using LihaApiA5.@interface;
using LihaApiA5.models;
using LIhaApiA5.Data.Repositorios;
using MySql.Data.MySqlClient;

namespace LihaApiA5.Repositorios
{
    public class ClienteCarteraRepository : IClienteCartera
    {
        private readonly MySqlConfiguration2 _connectionString2;

        public ClienteCarteraRepository(MySqlConfiguration2 connectionString2)
        {
            _connectionString2 = connectionString2;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString2.ConnectionString2);
        }


        public Task<IEnumerable<ClienteCarteraModel>> GetCartera(String CodigoCliente)
        {
            var db = dbConnection();
            var sql = @"SELECT DISTINCT saldos_clientes.NumeroFacturaCompleto AS Factura, saldos_clientes.NumeroCuotaCreditoDetalle AS N_Cuota, saldos_clientes.Saldo, saldos_clientes.FechaFacturaCabecera AS FechaEmision, saldos_clientes.FechaVecimientoCreditoDetalle AS FechaVencimiento, DATEDIFF( saldos_clientes.FechaVecimientoCreditoDetalle, CURDATE()) AS DiasVencimiento, IFNULL(Saldo_Vencido, '0') AS SALDOVENCIDO, CASE WHEN DATEDIFF( saldos_clientes.FechaVecimientoCreditoDetalle, CURDATE()) < 0 THEN CONCAT( 'Vencido ', ABS( DATEDIFF( saldos_clientes.FechaVecimientoCreditoDetalle, CURDATE()))) WHEN DATEDIFF( saldos_clientes.FechaVecimientoCreditoDetalle, CURDATE()) > 0 THEN CONCAT( 'Vence en ', DATEDIFF( saldos_clientes.FechaVecimientoCreditoDetalle, CURDATE())) ELSE 'Vence hoy' END AS DiasVencimiento FROM saldos_clientes LEFT JOIN saldos_vencidos ON saldos_vencidos.CodigoFacturaCabecera = saldos_clientes.CodigoFacturaCabecera WHERE saldos_clientes.ClientesFacturaCabecera = @codigo ORDER BY saldos_clientes.NumeroFacturaCompleto,saldos_clientes.NumeroCuotaCreditoDetalle,FechaFacturaCabecera;";
            return db.QueryAsync<ClienteCarteraModel>(sql, new { codigo = CodigoCliente});
        }


        public Task<IEnumerable<ClienteCupoModel>> GetCupo(String CodigoCliente)
        {
            var db = dbConnection();
            var sql = @"select CodigoCliente,Cupo_Aprobado, (Cupo_Aprobado-(Saldo+Cheques)) As CupoDisponible from cupo_clientes  where CodigoCliente= @codigo;"; 
            return db.QueryAsync<ClienteCupoModel>(sql, new { codigo = CodigoCliente});
        }

    }
}
