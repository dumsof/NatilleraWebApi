namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarioRepositorie : IRepositoryBase<UsuariosEntity>
    {
        Task<IEnumerable<UsuariosEntity>> ObtenerUsuariosAsync();

        Task<bool> EditarUsuarioAsync(UsuariosEntity usuario);

        Task<UsuariosEntity> GuardarUsuarioAsync(UsuariosEntity usuario, Guid socioId);

        Task<UsuariosEntity> LogueoAsync(UsuariosEntity usuario);

        Task<bool> ExisteUsuarioAsync(UsuariosEntity usuario);

        Task<bool> DeleteUsuarioAsync(string usuarioId);
    }
}
