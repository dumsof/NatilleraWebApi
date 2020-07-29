namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Threading.Tasks;

    public interface ITokensRepositorio
    {
        Task<TokenEntity> ObtenerTokenAsync(string tokenRefresh);

        Task<bool> EditarTokenAsync(TokenEntity token);

        Task<TokenEntity> GuardarTokenAsync(TokenEntity token);       

        Task<bool> DeleteTokenAsync(string usuarioId);        
    }
}
