namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISociosRepositorie : IRepositoryBase<SociosEntity>
    {
        Task<Guid> GuardarSocioAsync(SociosEntity socio);

        public ICollection<SociosEntity> ObtenerSocios();
    }
}
