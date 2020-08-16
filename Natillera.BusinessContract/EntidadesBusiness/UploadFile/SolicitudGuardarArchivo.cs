namespace Natillera.BusinessContract.EntidadesBusiness.UploadFile
{
    using Microsoft.AspNetCore.Http;

    public class SolicitudGuardarArchivo
    {
        public IFormFile Archivo { get; set; }
    }
}
