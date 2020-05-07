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
                Email = usuario.NombreUsuario,
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

        public static UsuarioBusiness UsuarioEntityMap(Usuario usuario, Socio socio)
        {
            return new UsuarioBusiness
            {
                Nombres = socio?.Nombres,
                PrimerApellido = socio?.PrimerApellidos,
                SegundoApellido = socio?.SegundoApellidos,
                Direccion = socio?.Direccion,
                Celular = socio?.Celular,
                Telefono = socio?.Telefono,
                FechaNacimiento = socio.FechaNacimiento,
                NumeroDocumento = socio?.NumeroDocumento,
                TipoDocumentoId = socio.TipoDocumentoId,
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Email = usuario.Email,
                Password = usuario.Password,
                TiposDocumentoDescripcion = socio.TiposDocumentoDescripcion
            };
        }
    }
}
