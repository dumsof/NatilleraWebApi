namespace Natillera.DataAccess
{
    using Microsoft.AspNetCore.Identity;
    using Natillera.DataAccessContract.Entidades;
    using System;

    //se puede agregar propiedades para la tabla usuario.
    /// <summary>
    /// Defines the <see cref="ApplicationUser" />
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public Guid SocioId { get; set; }
        //relacion un socio puede pertenecer a diferentes natilleras
        public Socios Socios { get; set; }
    }
}
