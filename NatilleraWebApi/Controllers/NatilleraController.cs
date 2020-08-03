namespace NatilleraWebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Natillera;
    using NatilleraWebApi.Filter.ActionFilter;
    using System.Net;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class NatilleraController : ControllerBase
    {
        private readonly INatilleraService natilleraService;
        public NatilleraController(INatilleraService natilleraService)
        {
            this.natilleraService = natilleraService;
        }

        /// <summary>
        /// Guardar los datos de una natillera que ingresa el usuario.
        /// </summary>
        /// <param name="natillera"></param>
        /// <response code="200">Operación realizada con éxito.</response>
        /// <response code="401">No existen permisos para utilizar el servicio.</response>
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ActionName("GuardarNatillera")]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NatilleraAplication), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NatilleraAplication), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public IActionResult GuardarNatillera([FromBody] NatilleraAplication natillera)
        {

            Respuesta respuesta = this.natilleraService.GuardarNatillera(natillera);

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
        [ActionName("ObtenerNatilleras")]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NatilleraAplication), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(NatilleraAplication), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public IActionResult ObtenerNatillera()
        {

            Respuesta respuesta = this.natilleraService.ObtenerNatilleras();

            return new OkObjectResult(respuesta);
        }
    }
}