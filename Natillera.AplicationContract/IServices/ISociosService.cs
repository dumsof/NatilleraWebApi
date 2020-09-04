namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Socios;
    using System;
    using System.Threading.Tasks;

    public interface ISociosService
    {
        Task<Respuesta> GuardarSocioAsync(SocioAplication socio);

        Task<Respuesta> ActualizarSocioAsync(SocioAplication socio);

        Task<RespuestaObtenerSocios> ObtenerSociosAsync();

        Task<Respuesta> DeleteSocioAsync(Guid socioId);
    }
}
