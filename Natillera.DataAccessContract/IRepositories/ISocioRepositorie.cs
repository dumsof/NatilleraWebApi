﻿namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISocioRepositorie : IRepositoryBase<SocioEntity>
    {
        Task<Guid> GuardarSocioAsync(SocioEntity socio);

        public Task<IEnumerable<Socio>> ObtenerSociosAsync();

        Task<Socio> ObtenerSocioIdAsync(Guid socioId);

        Task<bool> DeleteSocioIdAsync(SocioEntity socio);
    }
}
