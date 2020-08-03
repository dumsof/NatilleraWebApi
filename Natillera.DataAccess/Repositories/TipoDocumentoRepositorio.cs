
namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TipoDocumentoRepositorio : RepositoryBase<TipoDocumentoEntity>, ITipoDocumentoRepositorio
    {
        private readonly NatilleraDBContext repositorioContexto;

        public TipoDocumentoRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            this.repositorioContexto = repositorioContexto;
        }

        public async Task<IEnumerable<TipoDocumentoEntity>> ObtenerTiposDocumentoAsync()
        {
            return await this.GetAllAsync();
        }
    }
}
