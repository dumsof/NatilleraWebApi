namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRolesRepositorio
    {
        Task<Roles> GuardarRolAsync(Roles roles);
        Task<bool> ExisteRolAsync(string nombreRol);
        Task<IEnumerable<Roles>> ObtenerRolesAsync();
        Task<bool> DeleteRolAsync(string rolId);
        Task<bool> EditarRolAsync(string rolId);
    }
}
