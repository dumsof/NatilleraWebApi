namespace NatilleraWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.Business.Models.Autentificacion;
    using NatilleraWebApi.Filter.ActionFilter;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutentificacionController : ControllerBase
    {
        private readonly IAuntentificacionService auntentificacionService;

        public AutentificacionController(IAuntentificacionService auntentificacionService)
        {
            this.auntentificacionService = auntentificacionService;
        }

        /// <summary>
        /// Valida si el usuario existe y la contraseña diligenciada es correcta.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <response code="200">Operación realizada con éxito.</response>
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> LogueoAsync([FromBody] UsuarioLogin userInfo)
        {
            var resultUserLogueado = await this.auntentificacionService.LogueoAsync(userInfo);

            return Ok(resultUserLogueado);
        }

        /// <summary>
        /// Genera de forma automatica un toquen cuando este vencido en la seción del usuario del front end.
        /// debera enviar el token vencido y el token de refresco.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <response code="200">Operación realizada con éxito.</response>
        /// <response code="404">No existen datos para la consulta realizada.</response>
        /// <response code="500">Error inesperado.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RequestRefreshToken refreshToken)
        {
            var resultUserNuevoTokenRefresh = await this.auntentificacionService.RefreshTokenAsync(refreshToken);

            return Ok(resultUserNuevoTokenRefresh);
        }
    }
}