using ClassLibraryEntity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.Interfaces
{
    public interface IUserData:IGenericRepository<UserPerson>
    {
        public Task<List<UserPerson>> GetAll(); 
    }
}
