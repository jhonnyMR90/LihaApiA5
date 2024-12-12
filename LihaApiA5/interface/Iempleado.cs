using LihaApiA5.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LihaApiA5.@interface
{
    public interface Iempleado
    {
        Task<IEnumerable<empleadoModel>> GetAllEmpleados();
    }
}
