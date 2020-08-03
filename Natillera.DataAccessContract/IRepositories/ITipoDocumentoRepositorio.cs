
namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITipoDocumentoRepositorio
    {
        Task<IEnumerable<TipoDocumentoEntity>> ObtenerTiposDocumentoAsync();
    }
}
