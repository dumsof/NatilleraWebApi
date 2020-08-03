namespace Natillera.Business.Business
{
    using AutoMapper;
    using Natillera.BusinessContract.EntidadesBusiness.Socios;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SocioBusiness : ISocioBusiness
    {
        private readonly ISocioRepositorie repositorio;
        private readonly IMapper mapper;
        public SocioBusiness(ISocioRepositorie repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteSocioAsync(Guid socioId)
        {
            var socioDelete = await this.repositorio.Find(c => c.SocioId == socioId);
            if (socioDelete != null)
            {

                await this.repositorio.DeleteAsync(socioDelete);
                return true;
            }

            return false;
        }

        public async Task<Guid> GuardarSocioAsync(SocioENegocio sociosBusiness)
        {
            var result = await this.repositorio.GuardarSocioAsync(this.mapper.Map<SocioEntity>(sociosBusiness));

            return result;
        }

        public async Task<SocioENegocio> ObtenerSocioIdAsync(Guid socioId)
        {
            var result = await this.repositorio.ObtenerSocioIdAsync(socioId);

            return this.mapper.Map<SocioENegocio>(result);
        }

        public async Task<IEnumerable<SocioENegocio>> ObtenerSociosAsync()
        {
            var result = await this.repositorio.ObtenerSociosAsync();

            var socio = this.mapper.Map<IEnumerable<SocioENegocio>>(result);

            return socio;
        }
    }
}
