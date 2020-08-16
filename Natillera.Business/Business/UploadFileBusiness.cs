namespace Natillera.Business.Business
{
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using Natillera.BusinessContract.IBusiness;
    using System;
    using System.Threading.Tasks;
    using System.IO;

    public class UploadFileBusiness : IUploadFileBusiness
    {
        public async Task<string> UnloadFile(SolicitudGuardarArchivo guardarArchivo)
        {
            string rutaArchivoGuardado = string.Empty;

            if (guardarArchivo.Archivo.Length > 0)
            {
                var rutaCompleta = this.GetPathToSave();
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

        private string GetPathToSave()
        {
            var nombreCarpeta = Path.Combine("Resources", "Imagenes");

            return Path.Combine(Directory.GetCurrentDirectory(), nombreCarpeta);
        }
    }
}
