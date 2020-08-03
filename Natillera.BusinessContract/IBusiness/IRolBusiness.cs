namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.Roles;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRolBusiness
    {
        Task<RolENegocio> GuardarRolAsync(RolENegocio rol);

        Task<bool> ExisteRolAsync(string nombreRol);

        Task<IEnumerable<RolENegocio>> ObtenerRolesAsync();

        Task<bool> DeleteRolAsync(string rolId);

        Task<bool> EditarRolAsync(string rolId);
    }
}
