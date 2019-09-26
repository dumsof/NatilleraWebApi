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
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> ExistAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<T> UpdateAsync(int id, T datosActualizar);

        Task<T> AddAsync(T datosActualizar);

    }
}
