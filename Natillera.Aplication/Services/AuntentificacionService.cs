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
        private readonly ITokensRepositorio tokensRepositorio;
        private readonly ITokensService tokensService;

        public AuntentificacionService(IUsuarioRepositorie usuarioRepositorie, ISocioRepositorie socioRepositorie, IConfiguration configuration, ITokensRepositorio tokensRepositorio, ITokensService tokensService)
        {
            this.usuarioRepositorie = usuarioRepositorie;
            this.socioRepositorie = socioRepositorie;
            this.configuration = configuration;
            this.tokensRepositorio = tokensRepositorio;
            this.tokensService = tokensService;
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
                var token = this.tokensService.CrearToken(usuario?.Id, usuario?.Email);

                var tokenRefresh = this.tokensService.GenerateTokenRefresh();

                await this.tokensRepositorio.GuardarTokenAsync(new TokenEntity { UserId = usuario?.Id, Token = tokenRefresh.Token, FechaExpiraToken = tokenRefresh.FechaExpiracion });

                return new RespuestaLogueo
                {
                    EstadoTransaccion = true,
                    Usuario = UsuarioMapper.UsuarioEntityMap(usuario, socio),
                    Token = token.Token,
                    TokenRefresh = tokenRefresh.Token,
                    FechaExpirationToken = token.FechaExpiracion,
                    Mensaje = new Message(MessageCode.Message0000).Mensaje
                };
            }

            return new RespuestaLogueo
            {
                EstadoTransaccion = false,
                Mensaje = new Message(MessageCode.Message0003).Mensaje
            };
        }
    }
}
