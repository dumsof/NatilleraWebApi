namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.Socios;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISocioBusiness
    {
        Task<Guid> GuardarSocioAsync(SocioENegocio sociosBusiness);

        Task ActualizarSocioAsync(SocioENegocio sociosBusiness);

        Task<bool> NoFueModificadoOtroUsuarioConcurrente(SocioENegocio sociosBusiness);

        Task<IEnumerable<SocioENegocio>> ObtenerSociosAsync();

        Task<SocioENegocio> ObtenerSocioIdAsync(Guid socioId);

        Task<bool> DeleteSocioAsync(Guid socioId);
    }
}
