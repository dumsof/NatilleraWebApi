namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;

    public class NatilleraRepositorio : RepositoryBase<NatilleraEntity>, INatilleraRepositorie
    {
        public NatilleraRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
        }
    }
}
