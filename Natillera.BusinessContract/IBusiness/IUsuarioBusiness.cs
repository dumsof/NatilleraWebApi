namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarioBusiness
    {
        Task<UsuarioENegocio> GuardarUsuarioAsync(UsuarioENegocio usuario);

        Task<bool> EditarUsuarioAsync(UsuarioENegocio usuario);

        Task<UsuarioENegocio> ObtenerUsuarioPorNombreAsync(string nombreUsuario);

        Task<bool> DeleteUsuarioAsync(string usuarioId);

        Task<IEnumerable<UserENegocio>> ObtenerUsuariosAsync();

        Task<bool> UsuarioEsValidoAsync(UsuarioENegocio usuario);
    }
}