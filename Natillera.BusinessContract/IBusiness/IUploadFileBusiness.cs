namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using System.Threading.Tasks;


    public interface IUploadFileBusiness
    {
        Task<string> UnloadFile(SolicitudGuardarArchivo guardarArchivo);

        bool EsImagen(string contentType);
    }
}
