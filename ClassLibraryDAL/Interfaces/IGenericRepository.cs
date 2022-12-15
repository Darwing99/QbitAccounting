using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
      
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filtro);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Create(TEntity entidad);
        Task<bool> Edit(TEntity entidad);
        
        Task<bool> Delete(TEntity entidad);
        Task<IQueryable<TEntity>> Search(Expression<Func<TEntity, bool>> filtro = null);
    }
}
