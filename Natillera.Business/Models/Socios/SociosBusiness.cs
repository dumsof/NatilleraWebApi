namespace Natillera.Business.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SociosBusiness
    {
        public Guid SocioId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(12, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]

        public string NumeroDocumento { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string PrimerApellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string SegundoApellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(12, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(15, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Direccion { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "En el campo {0} debe diligenciar un email válido, por favor verifique.")]
        public string Email { get; set; }

        //propiedades que se utilizan para las relaciones
        /*Relacion uno a uno con el tipo de documento*/
        public Guid TipoDocumentoId { get; set; }
    }
}
