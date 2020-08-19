﻿namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.UnloadFile;
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System.IO;
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

        public Task<string> UnloadFile()
        {
            //Dum: subir archivo con angular https://www.youtube.com/watch?v=v67NunIp5w8
            //Dum: subir archivo co postman

            var archivo = "";
            var nombreCarpeta = Path.Combine("Resources", "Imagenes");
            var rutaAGuardar = Path.Combine(Directory.GetCurrentDirectory(), nombreCarpeta);
            var rutaCompleta = $"{nombreCarpeta}{rutaAGuardar}";

            //using (var stream = new FileStream())



            throw new System.NotImplementedException();
        }



        private string GetPathToSave()
        {
            var nombreCarpeta = Path.Combine("Resources", "Imagenes");

            return Path.Combine(Directory.GetCurrentDirectory(), nombreCarpeta);
        }

        private bool EsImagen(string tipoArchvio)
        {
            bool esImagen = false;


            return esImagen;

        }

        public Task<(string fileType, byte[] archiveData, string archiveName)> DownloadFileAsync(string nombreArchivo)
        {
            return this.fileBusiness.DownloadFileAsync(nombreArchivo);
        }
    }
}
