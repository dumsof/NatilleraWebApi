namespace Natillera.AplicationContract.Models.Roles
{
    using Natillera.Business.Models.Roles;
    using System.Collections.Generic;

    public class RespuestaObtenerRoles : Respuesta
    {
        public IEnumerable<RolesBusiness> Roles { get; set; }
    }
}
