using ClassLibraryBLL.Interfaces;
using ClassLibraryDAL;
using ClassLibraryDAL.Implementations;
using ClassLibraryEntity.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBLL.Implementations
{
    public class UserNegocio : IUserNegocio
    {
        private readonly UserData UserData;
        public UserNegocio()
        {
            UserData = new UserData(new DbaccountingContext());
        }

        public Task<UserPerson> GetUserPerson(string user,string password)
        {

            return UserData.Get(c=>c.CorreoUser==user && c.Clave==password && c.IsActive==true);
        }

        public async Task<List<UserPerson>> ListUserPerson()
        {
            return await  UserData.GetAll();

        }

        public async void SaveUserPerson(UserPerson person)
        {
            await UserData.Create(person);
        }

        public void UpdateUserPerson(UserPerson person)
        {
            throw new NotImplementedException();
        }
    }
}
