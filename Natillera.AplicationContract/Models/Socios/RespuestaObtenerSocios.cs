namespace Natillera.AplicationContract.Models
{
    using Natillera.Business.Models;
    using System.Collections.Generic;

    public class RespuestaObtenerSocios : Respuesta
    {
        public ICollection<SociosBusiness> Socios { get; set; }
    }
}
