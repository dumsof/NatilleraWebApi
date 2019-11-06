namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;

    public interface IUsuarioServices
    {
        Respuesta GuardarUsuario(Usuario usuario);

        Usuario Logueo(Usuario usuario);
    }
}
