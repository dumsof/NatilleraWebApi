namespace Natillera.Aplication.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AuntentificacionService : IAuntentificacionService
    {
        private readonly IUsuarioRepositorie usuarioRepositorie;
        private readonly ISocioRepositorie socioRepositorie;
        private readonly IConfiguration configuration;

        public AuntentificacionService(IUsuarioRepositorie usuarioRepositorie, ISocioRepositorie socioRepositorie, IConfiguration configuration)
        {
            this.usuarioRepositorie = usuarioRepositorie;
            this.socioRepositorie = socioRepositorie;
            this.configuration = configuration;
        }

        public async Task<RespuestaLogueo> LogueoAsync(UsuarioLogin usuarioLogin)
        {
            bool existeUsuario = await this.usuarioRepositorie.UsuarioEsValidoAsync(UsuarioMapper.UsuarioEntityMap(usuarioLogin));
            if (existeUsuario)
            {
                Socio socio = null;
                var usuario = await this.usuarioRepositorie.ObtenerUsuarioAsync(usuarioLogin.NombreUsuario);
                if (usuario != null)
                {
                    socio = await this.socioRepositorie.ObtenerSocioIdAsync(usuario.SocioId);
                }
                var tuplaGenerarToken = this.CrearToken(usuarioLogin);
                return new RespuestaLogueo
                {
                    EstadoTransaccion = true,
                    Usuario = UsuarioMapper.UsuarioEntityMap(usuario, socio),
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


        private Tuple<string, DateTime> CrearToken(UsuarioLogin usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.NombreUsuario),
                new Claim("usuario", usuario.NombreUsuario), //se puede pasar cualquier valor 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //valor unico por token, identificador para poder revocar el token si se desea.
            };

            //la clave secrete debe tener una longitud de mas de 128 bit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["va_clave_super_secreta"]));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            int horaVencimientoToken = this.configuration.GetValue<int>("Token:HorasVencimientoToken");

            var expiration = DateTime.Now.AddHours(horaVencimientoToken);

            JwtSecurityToken token = new JwtSecurityToken(
                                                           issuer: this.configuration.GetValue<string>("Token:Issuer"),
                                                           audience: this.configuration.GetValue<string>("Token:Audience"),
                                                           claims: claims,
                                                           expires: expiration,
                                                           signingCredentials: credencial
                                    );

            return new Tuple<string, DateTime>(new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }
    }
}
