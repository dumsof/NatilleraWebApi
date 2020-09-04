namespace Natillera.BusinessContract.EntidadesBusiness.Socios
{
    using System;

    public class SocioENegocio : AuditoriaNegocio
    {
        public Guid SocioId { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Nombres { get; set; }

        public string PrimerApellidos { get; set; }

        public string SegundoApellidos { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        //propiedades que se utilizan para las relaciones
        /*Relacion uno a uno con el tipo de documento*/
        public Guid TipoDocumentoId { get; set; }

        public string TiposDocumentoDescripcion { get; set; }
    }
}