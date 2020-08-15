namespace NatilleraWebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Roles;   
    using NatilleraWebApi.Filter.ActionFilter;
    using NatilleraWebApi.Filter.Cache;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {

        private readonly IRolesService rolesService;

        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        /// <summary>
        /// Crear los roles que puede tener un usuario.
        /// </summary>
        /// <param name="rol"></param>
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> CrearRolAsync([FromBody] RolEAplication rol)
        {
            Respuesta respuesta = await this.rolesService.GuardarRolAsync(rol);
            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Editar los datos del rol.
        /// </summary>
        /// <param name="rol"></param>
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> EditarRolAsync([FromBody] RolEAplication rol)
        {
            Respuesta respuesta = await this.rolesService.EditarRolAsync(rol);
            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Obtener todos los roles.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(RespuestaObtenerRoles), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaObtenerRoles), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaObtenerRoles), (int)HttpStatusCode.InternalServerError)]
        [Cached(600)]
        public async Task<IActionResult> ObtenerRolesAsync()
        {
            RespuestaObtenerRoles respuesta = await this.rolesService.ObtenerRolesAsync();
            return new OkObjectResult(respuesta);
        }


        /// <summary>
        /// Borrar rol por id.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteRolAsync([FromBody] SolicitudDeleteRolAplication solicitudDelete)
        {
            Respuesta respuesta = await this.rolesService.DeleteRolAsync(solicitudDelete.Id);
            return new OkObjectResult(respuesta);
        }
    }
}