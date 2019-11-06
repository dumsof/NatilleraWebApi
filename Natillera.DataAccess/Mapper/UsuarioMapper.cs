namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;

    public class UsuarioMapper
    {
        public static Usuarios UsuarioEntityMap(Usuario usuario)
        {
            return new Usuarios
            {
                Email = usuario.Email,
                Password = usuario.Password
            };
        }

        public static Usuario UsuarioEntityMap(Usuarios usuario)
        {
            return new Usuario
            {
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
    }
}
