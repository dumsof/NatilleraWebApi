namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using System.Threading.Tasks;

    public interface IUsuarioServices
    {
        Task<Respuesta> GuardarUsuarioAsync(UsuarioBusiness usuario);

        Task<Respuesta> EditarUsuarioAsync(UsuarioBusiness usuario);        

        Task<RespuestaObtenerUsuario> ObtenerUsuariosAsync();

        Task<UsuarioBusiness> LogueoAsync(UsuarioLogin usuarioLogin);

        Task<Respuesta> DeleteUsuarioAsync(string usuarioId);
    }
}
