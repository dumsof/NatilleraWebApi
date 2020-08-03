namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.TipoDocumento;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface ITipoDocumentoBusiness
    {
        Task<IEnumerable<TipoDocumentoENegocio>> ObtenerTiposDocumentoAsync();
    }
}
