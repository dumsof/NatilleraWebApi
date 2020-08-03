namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Usuario;   
    using System.Threading.Tasks;

    public interface IUsuarioService
    {
        Task<Respuesta> GuardarUsuarioAsync(UsuarioAplication usuario);

        Task<Respuesta> EditarUsuarioAsync(UsuarioAplication usuario);        

        Task<RespuestaObtenerUsuario> ObtenerUsuariosAsync();       

        Task<Respuesta> DeleteUsuarioAsync(string usuarioId);
    }
}
