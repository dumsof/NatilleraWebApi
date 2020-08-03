namespace Natillera.AplicationContract.Models
{
    using global::Natillera.AplicationContract.Models.Natillera;  
    using System.Collections.Generic;

    public class RespuestaObtenerNatillera : Respuesta
    {
        public IEnumerable<NatilleraAplication> Natillera { get; set; }
    }
}
