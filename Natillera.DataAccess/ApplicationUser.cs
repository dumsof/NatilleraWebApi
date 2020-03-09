namespace Natillera.DataAccess
{
    using Microsoft.AspNetCore.Identity;
    using Natillera.DataAccessContract.Entidades;   

    //se puede agregar propiedades para la tabla usuario.
    /// <summary>
    /// Defines the <see cref="ApplicationUser" />
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        //relacion un socio puede pertenecer a diferentes natilleras
        public virtual Socios Socios { get; set; }
    }
}
