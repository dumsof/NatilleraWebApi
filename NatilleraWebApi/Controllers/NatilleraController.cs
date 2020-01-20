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
    [Authorize]
    public class NatilleraController : ControllerBase
    {
        private readonly INatilleraServices natilleraService;
        public NatilleraController(INatilleraServices natilleraService)
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
        [ProducesResponseType(typeof(Natillera), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Natillera), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public IActionResult GuardarNatillera([FromBody] Natillera natillera)
        {          

            Respuesta respuesta = this.natilleraService.GuardarNatillera(natillera);

            return new OkObjectResult(respuesta);
        }
    }
}