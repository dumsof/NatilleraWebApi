namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;
    using System.Collections.Generic;
    using System.Linq;

    public static class UsuarioMapper
    {

        public static UsuariosEntity UsuarioEntityMap(UsuarioLogin usuario)
        {
            return new UsuariosEntity
            {
                Email = usuario.Email,
                Password = usuario.Password
            };
        }
        public static UsuariosEntity UsuarioEntityMap(UsuarioBusiness usuario)
        {
            return new UsuariosEntity
            {
                Id = usuario.Id,
                Cedula = usuario.NumeroDocumento,
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

        public static IEnumerable<UsuarioBusiness> UsuarioEntityMap(IEnumerable<UsuariosEntity> usuario)
        {
            return usuario.Select(usuario => new UsuarioBusiness
            {
                Id = usuario.Id,
                NumeroDocumento = usuario.Cedula,
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

        public static UsuarioBusiness UsuarioEntityMap(UsuariosEntity usuario)
        {
            return new UsuarioBusiness
            {
                Id = usuario.Id,
                NumeroDocumento = usuario.Cedula,
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
