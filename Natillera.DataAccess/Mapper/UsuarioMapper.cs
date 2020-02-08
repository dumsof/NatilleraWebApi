namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Linq;

    public static class UsuarioMapper
    {

        public static Usuarios UsuarioEntityMap(UsuarioLogin usuario)
        {
            return new Usuarios
            {
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
        public static Usuarios UsuarioEntityMap(Usuario usuario)
        {
            return new Usuarios
            {
                Id = usuario.Id,
                Cedula = usuario.Cedula,
                Nombres = usuario.Nombres,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Direccion = usuario.Direccion,
                Celular = usuario.Celular,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                Password = usuario.Password
            };
        }

        public static IEnumerable<Usuario> UsuarioEntityMap(IEnumerable<Usuarios> usuario)
        {
            return usuario.Select(usuario => new Usuario
            {
                Id = usuario.Id,
                Cedula = usuario.Cedula,
                Nombres = usuario.Nombres,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Direccion = usuario.Direccion,
                Celular = usuario.Celular,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                Password = usuario.Password

            }).ToList();
        }

        public static Usuario UsuarioEntityMap(Usuarios usuario)
        {
            return new Usuario
            {
                Id = usuario.Id,
                Cedula = usuario.Cedula,
                Nombres = usuario.Nombres,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Direccion = usuario.Direccion,
                Celular = usuario.Celular,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
    }
}
