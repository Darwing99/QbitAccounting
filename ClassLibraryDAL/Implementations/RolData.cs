using ClassLibraryDAL.Interfaces;
using ClassLibraryEntity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.Implementations
{
    public class RolData:GenericRepository<Rol>,IRolData
    {
        private readonly DbaccountingContext _dbaccountingContext;
        public RolData(DbaccountingContext dbaccountingContext):base(dbaccountingContext)
        {
            _dbaccountingContext = dbaccountingContext;
        }   
    }
}
