namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models.Roles;
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Linq;

    public static class RolesMapper
    {
        public static RolesEntity RolesEntityMap(RolesBusiness rol)
        {
            return new RolesEntity
            {
                Id = rol.Id,
                NombreRol = rol.NombreRol
            };
        }

        public static IEnumerable<RolesBusiness> RolesEntityMap(IEnumerable<RolesEntity> roles)
        {
            return roles.Select(rol => new RolesBusiness
            {
                Id = rol.Id,
                NombreRol = rol.NombreRol

            }).ToList();
        }
    }
}
