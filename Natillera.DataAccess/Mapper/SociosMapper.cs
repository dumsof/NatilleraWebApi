﻿namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;
    using System;

    public static class SociosMapper
    {
        public static SociosEntity SociosEntityMap(SociosBusiness socios)
        {
            return new SociosEntity
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

        public static SociosEntity SociosEntityMap(UsuarioBusiness usuario)
        {
            return new SociosEntity
            {
                SocioId = Guid.NewGuid(),
                Celular = usuario.Celular,
                Direccion = usuario.Direccion,
                Email = usuario.Email,
                FechaNacimiento = usuario.FechaNacimiento,
                Nombres = usuario.Nombres,
                NumeroDocumento = usuario.NumeroDocumento,
                PrimerApellidos = usuario.PrimerApellido,
                SegundoApellidos = usuario.SegundoApellido,
                Telefono = usuario.SegundoApellido,
                TipoDocumentoId = usuario.TipoDocumentoId
            };
        }
    }
}
