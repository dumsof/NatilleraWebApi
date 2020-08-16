namespace Natillera.BusinessContract.EntidadesBusiness.UploadFile
{
    using Microsoft.AspNetCore.Http;

    public class SolicitudUploadFile
    {
        public IFormFile File { get; set; }
    }
}
