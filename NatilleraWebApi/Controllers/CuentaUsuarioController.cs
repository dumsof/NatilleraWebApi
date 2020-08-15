namespace NatilleraWebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Usuario;
    using NatilleraWebApi.Filter.ActionFilter;
    using NatilleraWebApi.Filter.Cache;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CuentaUsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioServices;

        private readonly IConfiguration configuration;

        public CuentaUsuarioController(IUsuarioService usuarioServices, IConfiguration configuration)
        {
            this.usuarioServices = usuarioServices;
            this.configuration = configuration;
        }

        /// <summary>
        /// Guardar los datos del usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        [Cached(600, "/api/CuentaUsuario/ObtenerUsuarios")] //permite borrar el cache;
        public async Task<IActionResult> CrearUsuarioAsync([FromBody] UsuarioAplication usuario)
        {
            Respuesta respuesta = await this.usuarioServices.GuardarUsuarioAsync(usuario);
            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Editar los datos del usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        [Cached(600, "/api/CuentaUsuario/ObtenerUsuarios")]
        public async Task<IActionResult> EditarUsuarioAsync([FromBody] UsuarioAplication usuario)
        {
            Respuesta respuesta = await this.usuarioServices.EditarUsuarioAsync(usuario);
            return new OkObjectResult(respuesta);
        }

        /// <summary>
        /// Obtener todos los usuario.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpGet]
        [ProducesResponseType(typeof(RespuestaObtenerUsuario), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RespuestaObtenerUsuario), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestaObtenerUsuario), (int)HttpStatusCode.InternalServerError)]
        [Cached(600)]
        public async Task<IActionResult> ObtenerUsuariosAsync()
        {
            RespuestaObtenerUsuario respuesta = await this.usuarioServices.ObtenerUsuariosAsync();
            return new OkObjectResult(respuesta);
        }


        /// <summary>
        /// Borrar usuario por id.
        /// </summary>        
        /// <response code="200">Operación realizada con éxito.</response>z
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [Cached(600, "/api/CuentaUsuario/ObtenerUsuarios")]
        public async Task<IActionResult> DeleteUsuarioAsync([FromBody] SolicitudDeleteUsuarioAplication solicitudDelete)
        {
            Respuesta respuesta = await this.usuarioServices.DeleteUsuarioAsync(solicitudDelete.UsuarioId);
            return new OkObjectResult(respuesta);
        }
    }
}
