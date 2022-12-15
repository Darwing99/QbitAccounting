using ClassLibraryBLL.Interfaces;
using ClassLibraryDAL;
using ClassLibraryDAL.Implementations;
using ClassLibraryEntity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Implementations
{
    public class RolBusisness : IRolBusisness
    {
        private readonly RolData rolData;
        public RolBusisness()
        {
            rolData = new RolData(new DbaccountingContext());
        }
    

        public async Task<List<Rol>> GetRol()
        {
            return await rolData.GetAll();
        }
    }
}
