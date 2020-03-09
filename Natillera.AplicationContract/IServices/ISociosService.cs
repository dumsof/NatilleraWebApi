namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;

    public interface ISociosService
    {
        Respuesta GuardarSocio(SociosBusiness sociosBusiness);

        RespuestaObtenerSocios ObtenerSocios();

        Respuesta BorrarSocio(int socioId);
    }
}
