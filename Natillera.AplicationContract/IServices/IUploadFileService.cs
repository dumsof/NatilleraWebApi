namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models.UnloadFile;
    using System.Threading.Tasks;

    public interface IUploadFileService
    {
        Task<RespuestaGuardarArchivoImagen> GuardarArchivoImagenAsync(RequestGuardarImagen solicitudImagen);

        Task<RespuestaGuardarArchivoImagen> GuardarArchivoAsync(RequestGuardarArchivo solicitudArchivo);

        Task<(string fileType, byte[] archiveData, string archiveName)> DownloadFileAsync(string nombreArchivo);

        Task<(string fileType, byte[] archiveData, string archiveName)> DownloadFileZipAsync(string nombreArchivo);
    }
}
