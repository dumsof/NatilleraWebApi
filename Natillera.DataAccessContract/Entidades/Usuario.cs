namespace Natillera.DataAccessContract.Entidades
{
    using System;

    public class Usuario
    {
        public string Id { get; set; }

        public Guid SocioId { get; set; }

        public string NombreUsuario { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
       
    }
}
