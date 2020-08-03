namespace Natillera.AplicationContract.Models.Socios
{
    using System.Collections.Generic;

    public class RespuestaObtenerSocios : Respuesta
    {
        public ICollection<SocioAplication> Socios { get; set; }
    }
}
