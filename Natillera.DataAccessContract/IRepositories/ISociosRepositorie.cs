namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;

    public interface ISociosRepositorie : IRepositoryBase<Socios>
    {
        public ICollection<Socios> ObtenerSocios();
    }
}
