namespace Natillera.AplicationContract.IServices
{
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using System.Threading.Tasks;

    public interface IUploadFileService
    {
        Task<string> UnloadFile();

        Task<string> UnloadFileImage(SolicitudUploadFile solicitudUploadFile);
    }
}
