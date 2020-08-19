namespace Natillera.Business.Business
{
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using Natillera.BusinessContract.IBusiness;
    using System;
    using System.Threading.Tasks;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using System.IO.Compression;
    using System.Linq;

    public class UploadFileBusiness : IUploadFileBusiness
    {
        private readonly IConfiguration configuration;

        public UploadFileBusiness(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> UnloadFileAsync(SolicitudGuardarArchivo guardarArchivo)
        {
            string rutaArchivoGuardado = string.Empty;

            if (guardarArchivo.Archivo.Length > 0)
            {
                var rutaCompleta = this.GetPathToSave(guardarArchivo.Archivo.ContentType);
                var nombreArchivo = guardarArchivo.Archivo.FileName;

                nombreArchivo = string.Format("{0:yyyMMddHHmmss}-{1}", DateTime.Now, nombreArchivo);

                if (!Directory.Exists(rutaCompleta))
                {
                    Directory.CreateDirectory(rutaCompleta);
                }

                using (FileStream fileStream = File.Create($"{rutaCompleta}\\{ nombreArchivo}"))
                {
                    await guardarArchivo.Archivo.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();

                    rutaArchivoGuardado = $"{rutaCompleta}\\{nombreArchivo}";
                }
            }

            return rutaArchivoGuardado;
        }

        public async Task<object> DownloadFileAsync(string nombreArchivo)
        {
            string rutaArchivoGuardado = string.Empty;

            var rutaCompleta = this.GetPathToSave("application/pdf");
            rutaCompleta = $"{rutaCompleta}\\{ nombreArchivo}";



            var memory = new MemoryStream();
            using (var stream=new FileStream(rutaCompleta, FileMode.Create))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(rutaCompleta);

           //return new FileStreamResult(memory, "application/pdf", nombreArchivo);

           // System.IO.File(memory, "application/pdf", nombreArchivo);

            return null;
               
        }


        //https://medium.com/@tocalai/upload-download-file-s-in-asp-net-core-1fa89166aab0
        //DUM: ruta para descargar archivo zip
        public (string fileType, byte[] archiveData, string archiveName) FetechFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine("D:\\webroot\\", subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }

        }

        private string GetPathToSave(string contentType)
        {
            bool tipoImagen = this.EsImagen(contentType);
            var nombreCarpeta = Path.Combine("Resources", tipoImagen ? "Imagenes" : "Archivos");

            return Path.Combine(Directory.GetCurrentDirectory(), nombreCarpeta);
        }

        public bool EsImagen(string contentType)
        {
            string tiposImagen = this.configuration.GetValue<string>("FormatoTipoArchivo:FormatoImagen");

            return tiposImagen.Contains(contentType);
        }

        public bool EsArchivoPermitido(string contentType)
        {
            string tipoArchivo = this.configuration.GetValue<string>("FormatoTipoArchivo:FormatoArchivo");

            return tipoArchivo.Contains(contentType);
        }
    }
}
