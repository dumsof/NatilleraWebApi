namespace Natillera.Business.Mapper
{
    using Natillera.BusinessContract.EntidadesBusiness.Socios;
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;   

    public static class UsuarioMapper
    {
        public static UsuarioENegocio UsuarioEntityMap(UsuarioENegocio usuario, SocioENegocio socio)
        {
            return new UsuarioENegocio
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
