namespace Natillera.Aplication.Services
{
    using AutoMapper;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Socios;
    using Natillera.BusinessContract.EntidadesBusiness.Socios;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SociosService : ISociosService
    {
        private readonly ISocioBusiness business;
        private readonly IMapper mapper;
        public SociosService(ISocioBusiness business, IMapper mapper)
        {
            this.business = business;
            this.mapper = mapper;
        }

        public async Task<Respuesta> GuardarSocioAsync(SocioAplication socio)
        {

            var result = await this.business.GuardarSocioAsync(this.mapper.Map<SocioENegocio>(socio));

            return new Respuesta
            {
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<RespuestaObtenerSocios> ObtenerSociosAsync()
        {
            var datosSocios = await this.business.ObtenerSociosAsync();

            return new RespuestaObtenerSocios
            {
                EstadoTransaccion = datosSocios != null,
                Socios = this.mapper.Map<List<SocioAplication>>(datosSocios),
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> DeleteSocioAsync(Guid socioId)
        {
            var result = await this.business.DeleteSocioAsync(socioId);
            return new Respuesta
            {
                EstadoTransaccion = result,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
