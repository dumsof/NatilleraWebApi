namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Roles;
    using Natillera.Business.Models.Roles;
    using System.Threading.Tasks;

    public interface IRolesServices
    {
        Task<Respuesta> DeleteRolAsync(string rolesId);

        Task<Respuesta> EditarRolAsync(RolesBusiness rol);       

        Task<Respuesta> GuardarRolAsync(RolesBusiness rol);

        Task<RespuestaObtenerRoles> ObtenerRolesAsync();
    }
}
