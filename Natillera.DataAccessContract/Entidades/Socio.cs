namespace Natillera.DataAccessContract.Entidades
{
    using System;

    public class Socio
    {
        public Guid SocioId { get; set; }

        public string UsuarioId { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Nombres { get; set; }

        public string PrimerApellidos { get; set; }

        public string SegundoApellidos { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid TipoDocumentoId { get; set; }

        public string TiposDocumentoDescripcion { get; set; }
    }
}
