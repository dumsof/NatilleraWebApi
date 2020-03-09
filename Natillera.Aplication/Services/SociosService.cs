namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;
    using System.Linq;


    public class SociosService: ISociosService
    {
        private readonly IRepositorioContenedor repositorio;
        public SociosService(IRepositorioContenedor repositorio)
        {
            this.repositorio = repositorio;
        }

        public Respuesta GuardarSocio(SociosBusiness sociosBusiness)
        {

            this.repositorio.Natillera.Create(NatilleraMapper.NatilleraEntityMap(natillera));
            this.repositorio.Save();
            this.repositorio.Dispose();

            return new Respuesta
            {
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public RespuestaObtenerNatillera ObtenerNatilleras()
        {
            var datosNatilleras = this.repositorio.Natillera.FindAll();
            var targetList = datosNatilleras
                              .Select(x => new Natillera()
                              {
                                  NatilleraId = x.NatilleraId,
                                  Nombre = x.Nombre,
                                  Descripcion = x.Descripcion,
                                  DiasGraciaMora = x.DiasGraciaMora,
                                  FechaInicioPagoCuota = x.FechaInicioPagoCuota,
                                  NumeroCuotas = x.NumeroCuotas,
                                  TipoPago = x.TipoPago,
                                  ValorCuotaPagar = x.ValorCuotaPagar,
                                  ValorMoraDiaFijo = x.ValorMoraDiaFijo,
                                  ValorMoraPagar = x.ValorMoraPagar
                              })
                              .ToList();
            this.repositorio.Dispose();

            return new RespuestaObtenerNatillera
            {
                EstadoTransaccion = targetList != null,
                Natillera = targetList,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public Respuesta BorrarNatillera(int natilleraId)
        {
            return new Respuesta
            {
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
