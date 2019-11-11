namespace Natillera.DataAccessContract.IRepositories
{  
    using Natillera.DataAccessContract.Entidades;
    using System.Threading.Tasks;

    public interface IUsuarioRepositorie : IRepositoryBase<Usuarios>
    {
        Task<Usuarios> GuardarUsuarioAsync(Usuarios usuario);

        Task<Usuarios> LogueoAsync(Usuarios usuario);
    }
}
