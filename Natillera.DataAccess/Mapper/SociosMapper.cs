namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;
    using System;

    public static class SociosMapper
    {
        public static Socios SociosEntityMap(SociosBusiness socios)
        {
            return new Socios
            {
                SocioId = Guid.NewGuid(),
                Celular = socios.Celular,
                Direccion = socios.Direccion,
                Email = socios.Email,
                FechaNacimiento = socios.FechaNacimiento,
                Nombres = socios.Nombres,
                NumeroDocumento = socios.NumeroDocumento,
                PrimerApellidos = socios.PrimerApellidos,
                SegundoApellidos = socios.SegundoApellidos,
                Telefono = socios.SegundoApellidos,
                TipoDocumentoId = socios.TipoDocumentoId
            };
        }
    }
}
