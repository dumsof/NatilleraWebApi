namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;

    public class UsuarioRepositorio : RepositoryBase<Usuarios>, IUsuarioRepositorie
    {
        public UsuarioRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
        }
    }
}
