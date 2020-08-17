namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models.UnloadFile;   
    using System.Threading.Tasks;

    public interface IUploadFileService
    {
        Task<string> UnloadFile();      

        Task<RespuestaGuardarArchivoImagen> GuardarArchivoImagen(RequestGuardarArchivo solicitudArchivo);

        Task<RespuestaGuardarArchivoImagen> GuardarArchivo(RequestGuardarArchivo solicitudArchivo);
    }
}
