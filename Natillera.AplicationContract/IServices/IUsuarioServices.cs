namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using System.Threading.Tasks;

    public interface IUsuarioServices
    {
        Task<Respuesta> GuardarUsuarioAsync(Usuario usuario);

        Task<RespuestaObtenerUsuario> ObtenerUsuariosAsync();

        Task<Usuario> LogueoAsync(UsuarioLogin usuarioLogin);
    }
}
