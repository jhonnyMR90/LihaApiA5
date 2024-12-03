using LIhaApiA5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LihaApiA5.@interface
{
    public interface IItem
    {
        Task<IEnumerable<itemModel>> GetAllItem();
    }
}
