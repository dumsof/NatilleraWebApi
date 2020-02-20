namespace Natillera.Aplication.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AuntentificacionService : IAuntentificacionService
    {
        private readonly IUsuarioRepositorie usuarioRepositorie;

        private readonly IConfiguration configuration;

        public AuntentificacionService(IUsuarioRepositorie usuarioRepositorie, IConfiguration configuration)
        {
            this.usuarioRepositorie = usuarioRepositorie;
            this.configuration = configuration;
        }

        public async Task<RespuestaLogueo> LogueoAsync(UsuarioLogin usuarioLogin)
        {
            var respuesta = await this.usuarioRepositorie.LogueoAsync(UsuarioMapper.UsuarioEntityMap(usuarioLogin));
            if (respuesta != null)
            {
                var usuario = UsuarioMapper.UsuarioEntityMap(respuesta);
                var tuplaGenerarToken = this.CrearToken(usuario);             

                return new RespuestaLogueo
                {
                    EstadoTransaccion = true,
                    Usuario = usuario,
                    Token = tuplaGenerarToken.Item1,
                    FechaExpirationToken = tuplaGenerarToken.Item2,                    
                    Mensaje = new Message(MessageCode.Message0000).Mensaje
                };
            }           
            return new RespuestaLogueo
            {
                EstadoTransaccion = false,               
                Mensaje = new Message(MessageCode.Message0003).Mensaje
            };
        }


        private Tuple<string, DateTime> CrearToken(Usuario usuario)
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

            return new Tuple<string, DateTime>(new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }
    }
}
