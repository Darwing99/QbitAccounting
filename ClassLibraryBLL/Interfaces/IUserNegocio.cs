using ClassLibraryEntity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Interfaces
{
    public interface IUserNegocio
    {
        Task<List<UserPerson>> ListUserPerson();
        Task<UserPerson> GetUserPerson(string user,string password);
        void SaveUserPerson(UserPerson person);
        void UpdateUserPerson(UserPerson person);
    }
}
