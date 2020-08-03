namespace Natillera.Aplication.Services
{
    using AutoMapper;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.TipoDocumento;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoBusiness business;
        private readonly IMapper mapper;
        public TipoDocumentoService(ITipoDocumentoBusiness business, IMapper mapper)
        {
            this.business = business;
            this.mapper = mapper;
        }

        public async Task<RespuestaTiposDocumento> ObtenerTiposDocumentoAsync()
        {
            var tipoDocumento = await this.business.ObtenerTiposDocumentoAsync();

            return new RespuestaTiposDocumento
            {
                TipoDocumentos = this.mapper.Map<List<TipoDocumentoAplication>>(tipoDocumento),
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
