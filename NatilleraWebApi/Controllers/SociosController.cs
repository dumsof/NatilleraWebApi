namespace NatilleraWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Natillera.AplicationContract.Models;
    using NatilleraWebApi.Filter.ActionFilter;
    using Natillera.Business.Models;
    using System.Net;
    using Natillera.AplicationContract.IServices;
    using Microsoft.AspNetCore.Authorization;


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
        [ActionName("GuardarSocio")]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Natillera), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Natillera), (int)HttpStatusCode.InternalServerError)]
        //[ValidateModel]
        public IActionResult GuardarSocio([FromBody] SociosBusiness socios)
        {
            Respuesta respuesta = this.sociosService.GuardarSocio(socios);

            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Obtener todos los datos de las natilleras.
        /// </summary>       
        /// <response code="200">Operación realizada con éxito.</response>
        /// <response code="401">No existen permisos para utilizar el servicio.</response>
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ActionName("ObtenerSocios")]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Natillera), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Natillera), (int)HttpStatusCode.InternalServerError)]      
        public IActionResult ObtenerSocios()
        {
            RespuestaObtenerSocios respuesta = this.sociosService.ObtenerSocios();

            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Borrar usuario por id.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ActionName("DeleteSocio")]
        [Authorize]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public IActionResult DeleteSocio([FromBody] SolicitudDeleteSocio solicitudDelete)
        {
            Respuesta respuesta = this.sociosService.DeleteSocio(solicitudDelete.SocioId);
            return new OkObjectResult(respuesta);
        }
    }
}