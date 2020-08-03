namespace Natillera.Business.Business
{
    using AutoMapper;
    using Natillera.BusinessContract.EntidadesBusiness.Roles;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RolBusiness : IRolBusiness
    {
        private readonly IRolesRepositorio rolRepositorio;
        private readonly IMapper mapper;
        public RolBusiness(IRolesRepositorio rolRepositorio, IMapper mapper)
        {
            this.rolRepositorio = rolRepositorio;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteRolAsync(string rolId)
        {
            var result = await this.rolRepositorio.DeleteRolAsync(rolId);

            return result;
        }

        public async Task<bool> EditarRolAsync(string rolId)
        {
            var result = await this.rolRepositorio.EditarRolAsync(rolId);

            return result;
        }

        public async Task<bool> ExisteRolAsync(string nombreRol)
        {
            var result = await this.rolRepositorio.ExisteRolAsync(nombreRol);

            return result;
        }

        public async Task<RolENegocio> GuardarRolAsync(RolENegocio rol)
        {
            var rolGuardado = await this.rolRepositorio.GuardarRolAsync(this.mapper.Map<RolesEntity>(rol));

            return this.mapper.Map<RolENegocio>(rolGuardado);
        }

        public async Task<IEnumerable<RolENegocio>> ObtenerRolesAsync()
        {
            var result = await this.rolRepositorio.ObtenerRolesAsync();

            return this.mapper.Map<List<RolENegocio>>(result);
        }
    }
}
