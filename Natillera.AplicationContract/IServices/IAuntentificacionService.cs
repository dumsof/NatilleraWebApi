namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models.Autentificacion;
    using Natillera.AplicationContract.Models.Usuario;
    using System.Threading.Tasks;

    public interface IAuntentificacionService
    {
        Task<RespuestaLogueo> LogueoAsync(RequestUsuarioLogin usuarioLogin);

        Task<RespuestaLogueo> RefreshTokenAsync(RequestRefreshToken refreshToken);
    }
}
