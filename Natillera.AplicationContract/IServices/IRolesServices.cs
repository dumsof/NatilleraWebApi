namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Roles;   
    using System.Threading.Tasks;

    public interface IRolesServices
    {
        Task<Respuesta> DeleteRolAsync(string rolesId);

        Task<Respuesta> EditarRolAsync(RolEAplication rol);       

        Task<Respuesta> GuardarRolAsync(RolEAplication rol);

        Task<RespuestaObtenerRoles> ObtenerRolesAsync();
    }
}
