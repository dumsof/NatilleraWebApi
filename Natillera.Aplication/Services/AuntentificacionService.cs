namespace Natillera.Aplication.Services
{
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.Autentificacion;
    using Natillera.AplicationContract.Models.Socios;
    using Natillera.AplicationContract.Models.Usuario;
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.Threading.Tasks;

    public class AuntentificacionService : IAuntentificacionService
    {
        private readonly IUsuarioBusiness usuarioBusiness;
        private readonly ISocioBusiness socioBusiness;
        private readonly IConfiguration configuration;
        private readonly ITokensRepositorio tokensRepositorio;
        private readonly ITokensService tokensService;
        private readonly IMapper mapper;

        public AuntentificacionService(IUsuarioBusiness usuarioBusiness, ISocioBusiness socioBusiness, IConfiguration configuration, ITokensRepositorio tokensRepositorio, ITokensService tokensService, IMapper mapper)
        {
            this.usuarioBusiness = usuarioBusiness;
            this.socioBusiness = socioBusiness;
            this.configuration = configuration;
            this.tokensRepositorio = tokensRepositorio;
            this.tokensService = tokensService;
            this.mapper = mapper;
        }

        public async Task<RespuestaLogueo> LogueoAsync(RequestUsuarioLogin usuarioLogin)
        {

            bool existeUsuario = await this.usuarioBusiness.UsuarioEsValidoAsync(new UsuarioENegocio { Email = usuarioLogin.Email, Password = usuarioLogin.Password });
            if (existeUsuario)
            {
                SocioAplication socio = null;
                UsuarioAplication usuariApli = null;
                var usuario = await this.usuarioBusiness.ObtenerUsuarioPorNombreAsync(usuarioLogin.Email);
                if (usuario != null)
                {
                    usuariApli = this.mapper.Map<UsuarioAplication>(usuario);
                    var resultSocio = await this.socioBusiness.ObtenerSocioIdAsync(usuario.SocioId);
                    socio = this.mapper.Map<SocioAplication>(resultSocio);

                }
                var token = this.tokensService.CrearToken(usuario?.Id, usuario?.Email);

                var tokenRefresh = this.tokensService.GenerateTokenRefresh();

                await this.tokensRepositorio.GuardarTokenAsync(new TokenEntity { UserId = usuario?.Id, Token = tokenRefresh.Token, FechaExpiraToken = tokenRefresh.FechaExpiracion });

                return new RespuestaLogueo
                {
                    EstadoTransaccion = true,
                    Usuario = UsuarioMapper.UsuarioEntityMap(usuariApli, socio),
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

        /// <summary>
        /// metodo que permite crear un nuveo token al usuario despues de vencido
        /// https://www.youtube.com/watch?v=AWnO_b8XIeA minuto 16:42
        /// </summary>
        /// <param name="refreshToken">parametro que contiene el token vencido y el token para refrescar</param>
        /// <returns>retorna los datos del usuario con el nuevo token y el mismo token de refresco.</returns>
        public async Task<RespuestaLogueo> RefreshTokenAsync(RequestRefreshToken refreshToken)
        {
            string nombreUsuario = this.tokensService.GetUserFromAccessToken(refreshToken.Token);
            var resultUsuario = await this.usuarioBusiness.ObtenerUsuarioPorNombreAsync(nombreUsuario);
            var user = this.mapper.Map<UsuarioAplication>(resultUsuario);
            if (user != null && this.ValidateRefreshToken(user, refreshToken.TokenRefresh))
            {
                var result = await this.socioBusiness.ObtenerSocioIdAsync(user.SocioId);
                var socio = this.mapper.Map<SocioAplication>(result);
                var token = this.tokensService.CrearToken(user?.Id, user?.Email);
                return new RespuestaLogueo
                {
                    EstadoTransaccion = true,
                    Usuario = UsuarioMapper.UsuarioEntityMap(user, socio),
                    Token = token.Token,
                    TokenRefresh = refreshToken.TokenRefresh,
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

        private bool ValidateRefreshToken(UsuarioAplication user, string tokenRefresh)
        {
            var refreshTokenUsuario = this.tokensRepositorio.ObtenerTokenAsync(tokenRefresh).Result;
            if (refreshTokenUsuario != null && refreshTokenUsuario.UserId == user.Id && refreshTokenUsuario.FechaExpiraToken > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }
    }
}
