namespace Natillera.BusinessContract.EntidadesBusiness.Usuario
{
    using System;

    public class UserENegocio
    {
        public string Id { get; set; }
        public Guid SocioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
