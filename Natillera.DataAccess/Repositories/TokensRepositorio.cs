namespace Natillera.DataAccess.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Linq;
    using System.Threading.Tasks;

    //pagina donde se consulta para el uso de la tabla de token
    //https://stackoverflow.com/questions/53659247/using-aspnetusertokens-table-to-store-refresh-token-in-asp-net-core-web-api

    public class TokensRepositorio : RepositoryBase<TokenEntity>, ITokensRepositorio
    {
        /// <summary>
        /// Defines the _userManager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;



        private readonly NatilleraDBContext repositorioContexto;


        public TokensRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            this.repositorioContexto = repositorioContexto;
        }


        public async Task<bool> DeleteTokenAsync(string usuarioId)
        {
            var result = await _userManager.RemoveAuthenticationTokenAsync(new ApplicationUser { Id = usuarioId }, "AppNatillera", "tokenName");

            return result.Succeeded;
        }

        public Task<bool> EditarTokenAsync(TokenEntity token)
        {

            throw new System.NotImplementedException();
        }

        public async Task<TokenEntity> GuardarTokenAsync(TokenEntity token)
        {
            var result = await this.AddAsync(token);
            this.Save();
            this.Dispose();

            return result;
        }

        public async Task<TokenEntity> ObtenerTokenAsync(string tokenRefresh)
        {
          var token =  await this.repositorioContexto.Tokens.Where(c => c.Token == tokenRefresh).OrderByDescending(o => o.FechaExpiraToken).FirstOrDefaultAsync();

            return token;
        }
    }
}
