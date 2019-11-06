namespace Natillera.DataAccessContract.Entidades
{
    using System.ComponentModel.DataAnnotations;

    public class Usuarios
    {
        [Key]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }
    }
}
