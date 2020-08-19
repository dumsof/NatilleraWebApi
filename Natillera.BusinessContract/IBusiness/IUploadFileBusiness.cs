namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using System.Threading.Tasks;


    public interface IUploadFileBusiness
    {
        Task<string> UnloadFileAsync(SolicitudGuardarArchivo guardarArchivo);

        bool EsImagen(string contentType);

        bool EsArchivoPermitido(string contentType);
    }
}
