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
    using System.Collections.Generic;

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

        public async Task<(string fileType, byte[] archiveData, string archiveName)> DownloadFileAsync(string nombreArchivo)
        {
            string tipoArchivo = GetMimeType(nombreArchivo);
            var rutaCompleta = this.GetPathToSave(tipoArchivo);

            rutaCompleta = $"{rutaCompleta}\\{ nombreArchivo}";

            var memory = new MemoryStream();

            using (var stream = new FileStream(rutaCompleta, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return (tipoArchivo, memory.ToArray(), nombreArchivo);
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

        private string GetMimeType(string nombreArchivo)
        {
            string extensionArchivo = nombreArchivo.Substring(nombreArchivo.LastIndexOf("."));
            var mimeType = new Dictionary<string, string>();

            mimeType.Add(".pdf", "application/pdf");
            mimeType.Add(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            mimeType.Add(".doc", "application/msword");
            mimeType.Add(".xls", "application/vnd.ms-excel");
            mimeType.Add(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            return mimeType[extensionArchivo];
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
