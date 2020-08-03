namespace Natillera.AplicationContract.Models.Usuario
{
    using System.ComponentModel.DataAnnotations;

    public class SolicitudDeleteUsuarioAplication
    {
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        public string UsuarioId { get; set; }
    }
}
