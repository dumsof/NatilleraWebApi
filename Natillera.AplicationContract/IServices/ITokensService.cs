namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models.RefreshToken;

    public interface ITokensService
    {
        RespuestaToken GenerateTokenRefresh();

        RespuestaToken CrearToken(string usuarioId, string nombreUsuario);

        string GetUserFromAccessToken(string tokenAcceso);

        RespuestaToken CrearToken2ASCII(string usuarioId);
    }
}
