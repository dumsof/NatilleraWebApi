namespace Natillera.AplicationContract.Models.Roles
{   
    using System.Collections.Generic;

    public class RespuestaObtenerRoles : Respuesta
    {
        public IEnumerable<RolEAplication> Roles { get; set; }
    }
}
