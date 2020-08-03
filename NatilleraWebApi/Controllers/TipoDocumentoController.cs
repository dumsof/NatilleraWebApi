using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Natillera.AplicationContract.IServices;
using Natillera.AplicationContract.Models.TipoDocumento;
using System.Net;
using System.Threading.Tasks;

namespace NatilleraWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TipoDocumentoController : ControllerBase
    {

        private readonly ITipoDocumentoService service;

        public TipoDocumentoController(ITipoDocumentoService service)
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
        [ProducesResponseType(typeof(RespuestaTiposDocumento), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaTiposDocumento), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaTiposDocumento), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerTiposDocumentoAsync()
        {
            RespuestaTiposDocumento respuesta = await this.service.ObtenerTiposDocumentoAsync();
            return new OkObjectResult(respuesta);
        }
    }
}
