using LihaApiA5.models;
using LIhaApiA5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LihaApiA5.@interface
{
    public interface IClienteVendedor
    {
        Task<IEnumerable<ClienteVendedorModel>> GetCliente(string NombreUsuarioEmpleado, string NombreApellidoNombreComercial);

    }
}
