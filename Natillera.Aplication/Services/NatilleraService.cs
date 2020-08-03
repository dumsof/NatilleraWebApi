namespace Natillera.Aplication.Services
{
    using AutoMapper;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Natillera;   
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System;
    using System.Linq;
    using m = BusinessContract.EntidadesBusiness.Natillera;

    public class NatilleraService : INatilleraService
    {
        private readonly INatilleraBusiness bussiness;
        private readonly IMapper mapper;
        public NatilleraService(INatilleraBusiness bussiness, IMapper mapper)
        {
            this.bussiness = bussiness;
            this.mapper = mapper;
        }

        public Respuesta GuardarNatillera(NatilleraAplication natillera)
        {

            this.bussiness.GuardarNatillera(this.mapper.Map<m.NatilleraENegocio>(natillera));

            return new Respuesta
            {
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public RespuestaObtenerNatillera ObtenerNatilleras()
        {
            var datosNatilleras = this.bussiness.ObtenerNatilleras();

            var targetList = datosNatilleras
                              .Select(x => new NatilleraAplication()
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


            return new RespuestaObtenerNatillera
            {
                EstadoTransaccion = targetList != null,
                Natillera = targetList,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public Respuesta BorrarNatillera(Guid natilleraId)
        {
            return new Respuesta
            {
                EstadoTransaccion = this.bussiness.BorrarNatillera(natilleraId),
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
