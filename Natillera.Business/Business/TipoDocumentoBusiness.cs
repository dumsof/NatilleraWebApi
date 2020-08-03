using Natillera.BusinessContract.EntidadesBusiness.TipoDocumento;
using Natillera.BusinessContract.IBusiness;
using System;
namespace Natillera.Business.Business

{
    using AutoMapper;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TipoDocumentoBusiness : ITipoDocumentoBusiness
    {
        private readonly ITipoDocumentoRepositorio repositorio;
        private readonly IMapper mapper;
        public TipoDocumentoBusiness(ITipoDocumentoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TipoDocumentoENegocio>> ObtenerTiposDocumentoAsync()
        {
            var tipoDocumentos = await this.repositorio.ObtenerTiposDocumentoAsync();

            return this.mapper.Map<List<TipoDocumentoENegocio>>(tipoDocumentos);
        }
    }
}
