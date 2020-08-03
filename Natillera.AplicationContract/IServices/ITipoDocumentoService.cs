namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models.TipoDocumento;
    using System.Threading.Tasks;

    public interface ITipoDocumentoService
    {
        Task<RespuestaTiposDocumento> ObtenerTiposDocumentoAsync();
    }
}
