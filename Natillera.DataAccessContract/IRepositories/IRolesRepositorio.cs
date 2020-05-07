namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRolesRepositorio
    {
        Task<RolesEntity> GuardarRolAsync(RolesEntity roles);
        Task<bool> ExisteRolAsync(string nombreRol);
        Task<IEnumerable<RolesEntity>> ObtenerRolesAsync();
        Task<bool> DeleteRolAsync(string rolId);
        Task<bool> EditarRolAsync(string rolId);
    }
}
