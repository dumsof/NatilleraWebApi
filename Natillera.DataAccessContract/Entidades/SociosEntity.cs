namespace Natillera.DataAccessContract.Entidades
{
    using System;  
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SociosEntity : Entity
    {
        [Key]
        public Guid SocioId { get; set; }

        [StringLength(20)]
        public string NumeroDocumento { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(200)]
        public string Nombres { get; set; }

        [StringLength(250)]
        public string PrimerApellidos { get; set; }

        [StringLength(250)]
        public string SegundoApellidos { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string Celular { get; set; }

        [StringLength(250)]
        public string Direccion { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        //propiedades que se utilizan para las relaciones
        /*Relacion uno a uno con el tipo de documento*/
        //public virtual TiposDocumentos TiposDocumentos { get; set; }       

        public Guid TipoDocumentoId { get; set; }

        [ForeignKey("TipoDocumentoId")]
        public TiposDocumentos TiposDocumentos { get; set; }
    }
}
