
namespace Natillera.Business.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "En el campo {0} debe diligenciar un email válido, por favor verifique.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(15, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        [MinLength(6, ErrorMessage = "El campo {0} debe contener mínimo {1} caracteres.")]
        public string Password { get; set; }
    }
}
