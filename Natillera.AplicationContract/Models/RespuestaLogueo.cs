namespace Natillera.AplicationContract.Models
{
    using Natillera.Business.Models;

    public class RespuestaLogueo : Respuesta
    {      
        public Usuario Usuario { get; set; }
    }
}
