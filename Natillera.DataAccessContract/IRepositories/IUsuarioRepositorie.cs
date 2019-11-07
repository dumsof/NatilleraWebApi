namespace Natillera.DataAccessContract.IRepositories
{  
    using Natillera.DataAccessContract.Entidades;
    using System.Threading.Tasks;

    public interface IUsuarioRepositorie : IRepositoryBase<Usuarios>
    {
        Task<Usuarios> GuardarUsuario(Usuarios usuario);

        Task<Usuarios> Logueo(Usuarios usuario);
    }
}
