namespace Natillera.DataAccess
{
    using Microsoft.AspNetCore.Identity;

    //se puede agregar propiedades para la tabla usuario.
    /// <summary>
    /// Defines the <see cref="ApplicationUser" />
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Nombres { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Cedula { get; set; }

        public string Direccion { get; set; }

        public string Celular { get; set; }
    }
}
