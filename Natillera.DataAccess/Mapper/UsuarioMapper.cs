namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Linq;

    public static class UsuarioMapper
    {

        public static Usuario UsuarioEntityMap(UsuarioLogin usuario)
        {
            return new Usuario
            {
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
        public static Usuario UsuarioEntityMap(UsuarioBusiness usuario)
        {
            return new Usuario
            {
                Email = usuario.Email,
                Password = usuario.Password
            };
        }

        public static IEnumerable<UsuarioBusiness> UsuarioEntityMap(IEnumerable<Usuario> usuario)
        {
            return usuario.Select(usuario => new UsuarioBusiness
            {
                Email = usuario.Email,
                Password = usuario.Password

            }).ToList();
        }

        public static UsuarioBusiness UsuarioEntityMap(Usuario usuario)
        {
            return new UsuarioBusiness
            {               
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
    }
}
