namespace Natillera.AplicationContract.Models.UnloadFile
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class RequestGuardarImagen
    {
        [Required(ErrorMessage = "El campo {0} es requerido debe seleccionar un archivo tipo imagen, png, jpeg, jpg, bmp. por favor verifique.")]
        
        public IFormFile Imagen { get; set; }
    }

    //Debe seleccionar un archivo con un formato valido, .pdf, word, excel, zip
}
