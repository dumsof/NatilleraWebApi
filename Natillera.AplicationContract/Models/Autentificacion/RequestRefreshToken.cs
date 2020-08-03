namespace Natillera.AplicationContract.Models.Autentificacion
{
    using System.ComponentModel.DataAnnotations;

    public class RequestRefreshToken
    {
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [MinLength(50, ErrorMessage = "El campo {0} debe contener minimo {1} caracteres.")]
        public string Token { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [MinLength(15, ErrorMessage = "El campo {0} debe contener minimo {1} caracteres.")]
        public string TokenRefresh { get; set; }
    }
}
