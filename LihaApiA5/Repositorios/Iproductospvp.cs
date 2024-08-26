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
        Task<IEnumerable<productospvp>> GetDetails(string CodigoVentaProducto);
        
        Task<IEnumerable<productospvp>> GetDetailsDescription(string DescripcionProducto);
        
        Task<IEnumerable<productospvp>> GetDetailsPalabra(string palabra);
    }
}
