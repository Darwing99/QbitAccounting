using ClassLibraryDAL.Interfaces;
using ClassLibraryEntity.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.Implementations
{
    public class UserData : GenericRepository<UserPerson>, IUserData
    {
        private readonly DbaccountingContext _dbaccountingContext;
        private List<UserPerson> _UserPersons;
        public UserData(DbaccountingContext dbContext) : base(dbContext)
        {
            _dbaccountingContext= dbContext;
            _UserPersons= new List<UserPerson>();   
        }
        public async Task<List<UserPerson>> GetAll()
        {
            var data = await _dbaccountingContext
                .UserPeople
                .Include(c=>c.IdRolNavigation)
                .ToListAsync();
            return data;
        }
    }
}
