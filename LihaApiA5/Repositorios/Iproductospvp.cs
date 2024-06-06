using LIhaApiA5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIhaApiA5.Data.Repositorios
{
    public interface Iproductospvp
    {
        Task<IEnumerable<productospvp>> GetAllProductos();

        Task<productospvp> GetDetails(string CodigoVentaProducto);
    }
}
