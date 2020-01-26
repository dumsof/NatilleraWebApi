namespace Natillera.AplicationContract.Models
{
    using Natillera.Business.Models;
    using System.Collections.Generic;

    public class RespuestaObtenerNatillera : Respuesta
    {
        public IEnumerable<Natillera> Natillera { get; set; }
    }
}
