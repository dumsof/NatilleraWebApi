namespace Natillera.AplicationContract.Models
{
    using Natillera.Business.Models;
    using System.Collections.Generic;

    public class RespuestaObtenerUsuario : Respuesta
    {
        public IEnumerable<UsuarioBusiness> Usuarios { get; set; }
    }
}
