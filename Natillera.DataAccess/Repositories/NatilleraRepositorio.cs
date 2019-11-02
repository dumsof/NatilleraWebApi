namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;

    public class NatilleraRepositorio : RepositoryBase<Natilleras>, INatilleraRepositorie
    {
        public NatilleraRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
        }
    }
}
