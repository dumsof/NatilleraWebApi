namespace Natillera.AplicationContract.Models
{
    using Natillera.Business.Models;
    using System;

    public class RespuestaLogueo : Respuesta
    {      
        public Usuario Usuario { get; set; }

        public string Token { get; set; }

        public DateTime FechaExpirationToken { get; set; }

    }
}
