namespace Natillera.DataAccess.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RolesRepositorio : RepositoryBase<RolesEntity>, IRolesRepositorio
    {
        /// <summary>
        /// Defines the _userManager
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;
        
        private readonly NatilleraDBContext repositorioContexto;

        public RolesRepositorio(RoleManager<IdentityRole> roleManager,           
             NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            _roleManager = roleManager;          
            this.repositorioContexto = repositorioContexto;
        }

        public async Task<RolesEntity> GuardarRolAsync(RolesEntity roles)
        {

            var rol = new IdentityRole
            {
                Name = roles.NombreRol
            };
            var result = await _roleManager.CreateAsync(rol);
            if (result.Succeeded)
            {
                return roles;
            }

            return null;
        }

        public async Task<bool> ExisteRolAsync(string nombreRol)
        {
            var registrosAspNetRoles = await _roleManager.FindByNameAsync(nombreRol);

            return registrosAspNetRoles != null;
        }

        public async Task<IEnumerable<RolesEntity>> ObtenerRolesAsync()
        {
            var rol = _roleManager.Roles.ToList();
            return await Task.Run(() =>
            {
                return rol.Select(s => new RolesEntity
                {
                    Id = s.Id,
                    NombreRol = s.Name
                });
            });
        }

        public async Task<bool> DeleteRolAsync(string rolId)
        {
            var registrosAspNetRol = await _roleManager.FindByIdAsync(rolId);
            var result = await _roleManager.DeleteAsync(registrosAspNetRol);

            return result.Succeeded;
        }

        public async Task<bool> EditarRolAsync(string rolId)
        {
            var userTemp = await _roleManager.FindByIdAsync(rolId);

            var result = await _roleManager.UpdateAsync(userTemp);

            return result.Succeeded;
        }
    }
}
