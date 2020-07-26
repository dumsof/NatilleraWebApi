namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.Business.Models.Autentificacion;
    using System.Threading.Tasks;

    public interface IAuntentificacionService
    {
        Task<RespuestaLogueo> LogueoAsync(UsuarioLogin usuarioLogin);

        Task<RespuestaLogueo> RefreshTokenAsync(RequestRefreshToken refreshToken);
    }
}
