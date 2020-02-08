namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarioRepositorie : IRepositoryBase<Usuarios>
    {
        Task<IEnumerable<Usuarios>> ObtenerUsuariosAsync();

        Task<Usuarios> GuardarUsuarioAsync(Usuarios usuario);

        Task<Usuarios> LogueoAsync(Usuarios usuario);

        Task<bool> ExisteUsuarioAsync(Usuarios usuario);
    }
}
