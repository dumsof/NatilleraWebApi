namespace Natillera.DataAccessContract.IRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// sitio ejemplo del patron repositorio: https://code-maze.com/net-core-web-development-part4/
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity>
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task DeleteAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);

        void Save();
    }
}