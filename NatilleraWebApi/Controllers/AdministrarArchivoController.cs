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
        [HttpGet]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GuardarArchivoImagen([FromForm] SolicitudUploadFile solicitudUpload)
        {
            var respuesta = await this.service.UnloadFileImage(solicitudUpload);
            return new OkObjectResult(respuesta);
        }

    }
}
