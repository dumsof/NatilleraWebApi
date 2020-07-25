
namespace Natillera.Business.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UsuarioBusiness
    {
        public string Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(15, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string SegundoApellido { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(10, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(12, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Celular { get; set; }       

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "En el campo {0} debe diligenciar un email válido, por favor verifique.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        [MinLength(7, ErrorMessage = "El campo {0} debe contener mínimo {1} caracteres.")]        
        [RegularExpression("^((?=.*?[AZ])(?=.*?[Az])(?=.*?[0-9])|(?=.*?[AZ])(?=.*?[az])(?=.*?[^a-zA-Z0-9])|(?=.*?[AZ])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[az])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{7,}$", ErrorMessage = " Las contraseñas deben tener al menos 8 caracteres y contener 3 de 4 de los siguientes: mayúsculas (AZ), minúsculas (az), número (0 -9) y caracteres especiales (p. Ej.! @ # $% ^ & *) ")]
        public string Password { get; set; }

        public Guid TipoDocumentoId { get; set; }

        public string TiposDocumentoDescripcion { get; set; }
    }
}
