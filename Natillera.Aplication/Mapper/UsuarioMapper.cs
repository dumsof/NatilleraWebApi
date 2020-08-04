namespace Natillera.DataAccess.Mapper
{
    using Natillera.AplicationContract.Models.Socios;
    using Natillera.AplicationContract.Models.Usuario;

    public static class UsuarioMapper
    {

        //public static Usuario UsuarioEntityMap(UsuarioLogin usuario)
        //{
        //    return new Usuario
        //    {
        //        Email = usuario.NombreUsuario,
        //        Password = usuario.Password
        //    };
        //}
        //public static Usuario UsuarioEntityMap(UsuarioBusiness usuario)
        //{
        //    return new Usuario
        //    {
        //        Email = usuario.Email,
        //        Password = usuario.Password
        //    };
        //}

        //public static IEnumerable<UsuarioBusiness> UsuarioEntityMap(IEnumerable<Usuario> usuario)
        //{
        //    return usuario.Select(usuario => new UsuarioBusiness
        //    {
        //        Email = usuario.Email,
        //        Password = usuario.Password

        //    }).ToList();
        //}

        public static UsuarioAplication UsuarioEntityMap(UsuarioAplication usuario, SocioAplication socio)
        {
            return new UsuarioAplication
            {
                SocioId = socio.SocioId,
                Nombres = socio?.Nombres,
                PrimerApellidos = socio?.PrimerApellidos,
                SegundoApellidos = socio?.SegundoApellidos,
                Direccion = socio?.Direccion,
                Celular = socio?.Celular,
                Telefono = socio?.Telefono,
                FechaNacimiento = socio.FechaNacimiento,
                NumeroDocumento = socio?.NumeroDocumento,
                TipoDocumentoId = socio.TipoDocumentoId,
                Id = usuario.Id,
                Email = usuario.Email,
                Password = usuario.Password,
                TiposDocumentoDescripcion = socio.TiposDocumentoDescripcion
            };
        }
    }
}
