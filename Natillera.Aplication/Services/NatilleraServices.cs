namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;
    using System.Linq;

    public class NatilleraServices : INatilleraServices
    {
        private readonly IRepositorioContenedor repositorio;
        public NatilleraServices(IRepositorioContenedor repositorio)
        {
            this.repositorio = repositorio;
        }      

        public Respuesta GuardarNatillera(Natillera natillera)
        {
            Message message = new Message(MessageCode.Message0000);

            this.repositorio.Natillera.Create(NatilleraMapper.NatilleraEntityMap(natillera));
            this.repositorio.Save();
            this.repositorio.Dispose();
            return new Respuesta
            {
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
            };
        }

        public RespuestaObtenerNatillera ObtenerNatilleras()
        {
            Message message = new Message(MessageCode.Message0000);

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
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
            };
        }

        public Respuesta BorrarNatillera(int natilleraId)
        {
            Message message = new Message(MessageCode.Message0000);

           
            return new Respuesta
            {
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
            };
        }
    }
}
