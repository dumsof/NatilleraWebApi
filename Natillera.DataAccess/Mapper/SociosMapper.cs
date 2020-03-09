namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;


    public class SociosMapper
    {
        public static Socios SociosEntityMap(SociosBusiness socios)
        {
            return new Socios
            {
                Celular = socios.Celular,
                Direccion = socios.Direccion,
                Email = socios.Email,
                FechaNacimiento = socios.FechaNacimiento,
                Nombres = socios.Nombres,
                NumeroDocumento = socios.NumeroDocumento,
                PrimerApellidos = socios.PrimerApellidos,
                SegundoApellidos = socios.SegundoApellidos,
                Telefono = socios.SegundoApellidos,
                TiposDocumentos = socios.TipoDocumento
            };
        }
    }
}
