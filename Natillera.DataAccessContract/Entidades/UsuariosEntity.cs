namespace Natillera.DataAccessContract.Entidades
{
    using System.ComponentModel.DataAnnotations;

    public class UsuariosEntity
    {
        public string Id { get; set; }

        public string Cedula { get; set; }

        public string Nombres { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        [Key]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }
    }
}
