namespace Natillera.BusinessContract.EntidadesBusiness.Usuario
{
    using System;

    public class UsuarioENegocio
    {
        public string Id { get; set; }

        public Guid SocioId { get; set; }

        public string NumeroDocumento { get; set; }

        public string Nombres { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid TipoDocumentoId { get; set; }

        public string TiposDocumentoDescripcion { get; set; }
    }
}
