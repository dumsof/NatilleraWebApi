namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.UnloadFile;
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System.Threading.Tasks;

    public class AdministracionArchivoService : IUploadFileService
    {
        private readonly IUploadFileBusiness fileBusiness;

        public AdministracionArchivoService(IUploadFileBusiness fileBusiness)
        {
            this.fileBusiness = fileBusiness;
        }

        public async Task<RespuestaGuardarArchivoImagen> GuardarArchivoAsync(RequestGuardarArchivo solicitudArchivo)
        {
            if (!this.fileBusiness.EsArchivoPermitido(solicitudArchivo.Archivo.ContentType))
            {
                return new RespuestaGuardarArchivoImagen
                {
                    EstadoTransaccion = false,
                    RutaImagenGuardada = string.Empty,
                    Mensaje = new Message(MessageCode.Message0005).Mensaje
                };
            }
            var rutaFile = await this.fileBusiness.UnloadFileAsync(new SolicitudGuardarArchivo { Archivo = solicitudArchivo.Archivo });

            return new RespuestaGuardarArchivoImagen
            {
                EstadoTransaccion = true,
                RutaImagenGuardada = rutaFile,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<RespuestaGuardarArchivoImagen> GuardarArchivoImagenAsync(RequestGuardarImagen solicitudImagen)
        {

            if (!this.fileBusiness.EsImagen(solicitudImagen.Imagen.ContentType))
            {
                return new RespuestaGuardarArchivoImagen
                {
                    EstadoTransaccion = false,
                    RutaImagenGuardada = string.Empty,
                    Mensaje = new Message(MessageCode.Message0004).Mensaje
                };
            }

            var rutaFile = await this.fileBusiness.UnloadFileAsync(new SolicitudGuardarArchivo { Archivo = solicitudImagen.Imagen });

            return new RespuestaGuardarArchivoImagen
            {
                EstadoTransaccion = true,
                RutaImagenGuardada = rutaFile,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }        

        public async Task<(string fileType, byte[] archiveData, string archiveName)> DownloadFileAsync(string nombreArchivo)
        {
            return await this.fileBusiness.DownloadFileAsync(nombreArchivo);
        }

        public async Task<(string fileType, byte[] archiveData, string archiveName)> DownloadFileZipAsync(string nombreArchivo)
        {
            return await this.fileBusiness.DownloadFileZipAsync(nombreArchivo);
        }
    }
}
