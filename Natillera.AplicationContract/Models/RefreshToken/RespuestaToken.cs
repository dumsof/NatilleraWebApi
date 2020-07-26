namespace Natillera.AplicationContract.Models.RefreshToken
{
    using System;
   
    public class RespuestaToken
    {
        public string Token { get; set; }

        public DateTime FechaExpiracion { get; set; }
    }
}
