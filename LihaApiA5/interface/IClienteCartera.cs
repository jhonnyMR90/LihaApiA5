using LihaApiA5.models;

namespace LihaApiA5.@interface
{
    public interface IClienteCartera
    {
        Task<IEnumerable<ClienteCarteraModel>> GetCartera(String CodigoCliente);

        Task<IEnumerable<ClienteCupoModel>> GetCupo(String CodigoCliente);
    }
}
