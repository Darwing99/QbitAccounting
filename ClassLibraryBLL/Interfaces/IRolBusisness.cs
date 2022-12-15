using ClassLibraryEntity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Interfaces
{
    public interface IRolBusisness
    {
        Task<List<Rol>> GetRol();
    }
}
