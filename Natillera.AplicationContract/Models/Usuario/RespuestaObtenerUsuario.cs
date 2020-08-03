namespace Natillera.AplicationContract.Models.Usuario
{
    using System.Collections.Generic;

    public class RespuestaObtenerUsuario : Respuesta
    {
        public IEnumerable<UserAplication> Usuarios { get; set; }
    }
}
