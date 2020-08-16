namespace Natillera.AplicationContract.Models.UnloadFile
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class SolicitudGuardarArchivoImagen
    {
        [Required(ErrorMessage = "El campo {0} es requerido debe seleccionar un archivo tipo imagen, por favor verifique.")]
        
        public IFormFile Archivo { get; set; }
    }
}
