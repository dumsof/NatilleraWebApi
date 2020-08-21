namespace NatilleraWebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.UnloadFile;
    using Natillera.BusinessContract.EntidadesBusiness.UploadFile;

    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class AdministrarArchivoController : ControllerBase
    {
        private readonly IUploadFileService service;

        public AdministrarArchivoController(IUploadFileService service)
        {
            this.service = service;

        }

        /// <summary>
        /// Obtener todos tipos de documentos que puede seleccionar el usuario.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RespuestaGuardarArchivoImagen), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivoImagen), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivoImagen), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GuardarArchivoImagen([FromForm] RequestGuardarImagen guardarImagen)
        {

            var respuesta = await this.service.GuardarArchivoImagenAsync(guardarImagen);
            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Permite almacenar todo tipo de archivo valido para el sistema, comprimidos, documentos, imagenes.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GuardarArchivo([FromForm] RequestGuardarArchivo guardarArchivo)
        {

            var respuesta = await this.service.GuardarArchivoAsync(guardarArchivo);
            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Permite descargar archivos segun el nombre del archivo enviado.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DownloadFileAsync(string nombreArchivo)
        {
            var (fileType, archiveData, archiveName) = await this.service.DownloadFileAsync(nombreArchivo);

            return File(archiveData, fileType, archiveName);
        }

        /// <summary>
        /// Permite descargar cualquier tipo de archivo en formato zip.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaGuardarArchivo), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DownloadFileZipAsync(string nombreArchivo)
        {
            var (fileType, archiveData, archiveName) = await this.service.DownloadFileZipAsync(nombreArchivo);

            return File(archiveData, fileType, archiveName);
        }

    }
}
