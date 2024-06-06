using LIhaApiA5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIhaApiA5.Data.Repositorios
{
    public interface Icategorias
    {
        Task<IEnumerable<categorias>> GetAllCategorias();

        Task<categorias> GetDetails(string CodigoCategoria);

        //Task<bool> InsertCategorias(categorias categoria);

        //Task<bool> UpdateCategorias(categorias categoria);

        //Task<bool> DeleteCategorias(categorias categoria);

    }
}
