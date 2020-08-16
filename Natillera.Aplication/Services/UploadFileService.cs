namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class UploadFileService : IUploadFileService
    {
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

        public async Task<string> UnloadFileImage(SolicitudUploadFile solicitudUploadFile)
        {
            string rutaArchivoGuardado = string.Empty;

            if (solicitudUploadFile.File.Length > 0)
            {
                var rutaCompleta = this.GetPathToSave();
                var nombreArchivo = solicitudUploadFile.File.FileName;
                nombreArchivo = string.Format("{0: yyyMMMddd HHmmss}_{1}", DateTime.Now, nombreArchivo);

                if (!Directory.Exists(rutaCompleta))
                {
                    Directory.CreateDirectory(rutaCompleta);
                }

                using (FileStream fileStream = File.Create($"{rutaCompleta}{ nombreArchivo}"))
                {
                    await solicitudUploadFile.File.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();

                    rutaArchivoGuardado = $"{rutaCompleta}\\{nombreArchivo}";
                }
            }

            return rutaArchivoGuardado;
        }


        private string GetPathToSave()
        {
            var nombreCarpeta = Path.Combine("Resources", "Imagenes");
            var rutaAGuardar = Path.Combine(Directory.GetCurrentDirectory(), nombreCarpeta);

            return rutaAGuardar;

        }
    }
}
