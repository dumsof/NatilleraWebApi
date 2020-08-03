namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INatilleraRepositorie : IRepositoryBase<NatilleraEntity>
    {
        Task<bool> GuardarNatillera(NatilleraEntity natillera);

        Task<IEnumerable<NatilleraEntity>> ObtenerNatilleras();

        Task<bool> BorrarNatillera(NatilleraEntity natillera);
    }
}
