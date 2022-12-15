using ClassLibraryDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbaccountingContext _dbContext;
    
        public GenericRepository(DbaccountingContext dbContext) {
        _dbContext= dbContext;
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filtro)
        {
            TEntity? entity;
            try
            {
                entity=await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
                
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<TEntity> Create(TEntity entidad)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Edit(TEntity entidad)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TEntity entidad)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Search(Expression<Func<TEntity, bool>> filtro = null)
        {
            IQueryable<TEntity> Query = filtro == null ?  _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(filtro);
            return  Query;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
    }
}
