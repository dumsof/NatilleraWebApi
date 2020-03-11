namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;
    using System.Linq;


    public class SociosService : ISociosService
    {
        private readonly IRepositorioContenedor repositorio;
        public SociosService(IRepositorioContenedor repositorio)
        {
            this.repositorio = repositorio;
        }

        public Respuesta GuardarSocio(SociosBusiness sociosBusiness)
        {

            this.repositorio.Socios.Create(SociosMapper.SociosEntityMap(sociosBusiness));
            this.repositorio.Save();
            this.repositorio.Dispose();

            return new Respuesta
            {
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public RespuestaObtenerSocios ObtenerSocios()
        {
            var datosSocios = this.repositorio.Socios.FindAll();

            var targetList = datosSocios
                              .Select(x => new SociosBusiness()
                              {
                                  SocioId = x.SocioId,
                                  Nombres = x.Nombres,
                                  PrimerApellidos = x.PrimerApellidos,
                                  SegundoApellidos = x.SegundoApellidos,
                                  Celular = x.Celular,
                                  Direccion = x.Direccion,
                                  Email = x.Email,
                                  FechaNacimiento = x.FechaNacimiento,
                                  NumeroDocumento = x.NumeroDocumento,
                                  Telefono = x.Telefono,
                                  TipoDocumentoId = x.TiposDocumentos.TipoDocumentoId
                              })
                              .ToList();

            this.repositorio.Dispose();

            return new RespuestaObtenerSocios
            {
                EstadoTransaccion = targetList != null,
                Socios = targetList,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public Respuesta DeleteSocio(int socioId)
        {
            return new Respuesta
            {
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
