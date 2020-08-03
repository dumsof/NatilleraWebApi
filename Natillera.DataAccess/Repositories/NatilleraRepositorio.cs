namespace Natillera.DataAccess.Repositories
{

    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NatilleraRepositorio : RepositoryBase<NatilleraEntity>, INatilleraRepositorie
    {
        private readonly NatilleraDBContext repositorioContexto;
        public NatilleraRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            this.repositorioContexto = repositorioContexto;
        }

        public async Task<bool> GuardarNatillera(NatilleraEntity natillera)
        {
            var result = await this.AddAsync(natillera);
            this.Save();

            return result?.NatilleraId.ToString().Length > 0;
        }

        public async Task<IEnumerable<NatilleraEntity>> ObtenerNatilleras()
        {
            return await this.GetAllAsync();
        }

        public async Task<bool> BorrarNatillera(NatilleraEntity natillera)
        {
            await this.DeleteAsync(natillera);

            return true;
        }
    }
}
