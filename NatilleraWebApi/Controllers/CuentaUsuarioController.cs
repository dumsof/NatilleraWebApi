namespace NatilleraWebApi.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using NatilleraWebApi.Filter.ActionFilter;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class CuentaUsuarioController : ControllerBase
    {
        private readonly IUsuarioServices usuarioServices;

        private readonly IConfiguration configuration;

        public CuentaUsuarioController(IUsuarioServices usuarioServices, IConfiguration configuration)
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
        [ActionName("CrearUsuario")]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Respuesta), (int)HttpStatusCode.InternalServerError)]
        [ValidateModel]
        public async Task<IActionResult> CrearUsuarioAsync([FromBody] Usuario usuario)
        {
            Respuesta respuesta = await this.usuarioServices.GuardarUsuarioAsync(usuario);
            return new OkObjectResult(respuesta);
        }


        /// <summary>
        /// Guardar los datos del usuario.
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

            var resultUserLogueado = await this.usuarioServices.LogueoAsync(userInfo);
            if (resultUserLogueado != null)
            {
                return BuildToken(resultUserLogueado);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Logueo invalido, por favor verifique.");
                return Ok(new
                {
                    estadoTransaccion = false,
                    mensaje = new
                    {
                        identificador = 1,
                        titulo = "Proceso no Exitoso",
                        contenido = "Logueo invalido, por favor verifique."
                    }
                });
            }

        }

        private IActionResult BuildToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email),
                new Claim("miValor", "lo que yo quiera"), //se puede pasar cualquier valor 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //valor unico por token, identificador para poder revocar el token si se desea.
            };


            //la clave secrete debe tener una longitud de mas de 128 bit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["va_clave_super_secreta"]));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                                                           issuer: "yourdomain.com",
                                                           audience: "yourdomain.com",
                                                           claims: claims,
                                                           expires: expiration,
                                                           signingCredentials: credencial
                                    );

            return Ok(new
            {
                id = usuario.Id,
                nombres = usuario.Nombres,
                primerapellido = usuario.PrimerApellido,
                segundoapellido = usuario.SegundoApellido,
                direccion = usuario.Direccion,
                telefono = usuario.Telefono,
                celular = usuario.Celular,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiracion = expiration,
                estadoTransaccion = true,
                mensaje = new
                {
                    identificador = 0,
                    titulo = "Proceso Exitoso",
                    contenido = "El proceso ha sido exitoso"
                }
            });
        }
    }
}