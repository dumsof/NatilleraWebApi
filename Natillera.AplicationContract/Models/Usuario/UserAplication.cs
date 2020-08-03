namespace Natillera.AplicationContract.Models.Usuario
{
    using System;

    public class UserAplication
    {
        public string Id { get; set; }
        public Guid SocioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
