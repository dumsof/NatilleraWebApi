namespace Natillera.DataAccess.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        private bool disposed = false;

        protected NatilleraDBContext RepositoryContext { get; set; }

        public RepositoryBase(NatilleraDBContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<TEntity> FindAll()
        {
            return this.RepositoryContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this.RepositoryContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public void Create(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Remove(entity);
        }

        //DUM: metodos asincronos : https://blog.zhaytam.com/2019/03/14/generic-repository-pattern-csharp/
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await this.RepositoryContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }





        public Task DeleteAsync(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Remove(entity);
            return this.RepositoryContext.SaveChangesAsync();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<TEntity> GetByIdAsync(int id) => await this.RepositoryContext.Set<TEntity>().FindAsync(id);

        public Task UpdateAsync(TEntity entity)
        {
            this.RepositoryContext.Entry(entity).State = EntityState.Modified;
            return this.RepositoryContext.SaveChangesAsync();
        }  

       

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        Task IRepositoryBase<TEntity>.UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.RepositoryContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
