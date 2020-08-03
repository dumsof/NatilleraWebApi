namespace Natillera.AplicationContract.Models.Usuario
{   
    using System;

    public class RespuestaLogueo : Respuesta
    {
        public UsuarioAplication Usuario { get; set; }

        public string Token { get; set; }

        public string TokenRefresh { get; set; }

        public DateTime FechaExpirationToken { get; set; }

    }
}
