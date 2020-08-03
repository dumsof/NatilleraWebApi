namespace NatilleraWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Natillera.AplicationContract.Models;
    using NatilleraWebApi.Filter.ActionFilter;
    using System.Net;
    using Natillera.AplicationContract.IServices;
    using Microsoft.AspNetCore.Authorization;
    using Natillera.AplicationContract.Models.Socios;
    using System.Threading.Tasks;

    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class SociosController : ControllerBase
    {
        private readonly ISociosService sociosService;
        public SociosController(ISociosService sociosService)
        {
            this.sociosService = sociosService;
        }

        /// <summary>
        /// Guardar los datos de una natillera que ingresa el usuario.
        /// </summary>
        /// <param name="socios"></param>
        /// <response code="200">Operación realizada con éxito.</response>
        /// <response code="401">No existen permisos para utilizar el servicio.</response>
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> GuardarSocioAsync([FromBody] SocioAplication socios)
        {
            Respuesta respuesta = await this.sociosService.GuardarSocioAsync(socios);

            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Obtener todos los datos de las natilleras.
        /// </summary>       
        /// <response code="200">Operación realizada con éxito.</response>
        /// <response code="401">No existen permisos para utilizar el servicio.</response>
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(RespuestaObtenerSocios), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaObtenerSocios), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaObtenerSocios), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerSociosAsync()
        {
            RespuestaObtenerSocios respuesta = await this.sociosService.ObtenerSociosAsync();

            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Borrar usuario por id.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        //[ActionName("DeleteSocioAsync")]
        [Authorize]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> DeleteSocioAsync([FromBody] RequestDeleteSocioAplication solicitudDelete)
        {
            Respuesta respuesta = await this.sociosService.DeleteSocioAsync(solicitudDelete.SocioId);
            return new OkObjectResult(respuesta);
        }
    }
}