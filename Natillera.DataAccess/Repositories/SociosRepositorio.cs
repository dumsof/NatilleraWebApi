namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;

    public class SociosRepositorio : RepositoryBase<Socios>, ISociosRepositorie
    {
        public SociosRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
        }
    }
}
