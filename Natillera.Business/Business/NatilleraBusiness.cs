namespace Natillera.Business.Business
{
    using Natillera.BusinessContract.IBusiness;
    using Natillera.BusinessContract.EntidadesBusiness.Natillera;
    using System.Collections.Generic;
    using Natillera.DataAccessContract.IRepositories;
    using System;  
    using AutoMapper;
    using Natillera.DataAccessContract.Entidades;

    public class NatilleraBusiness : INatilleraBusiness
    {
        private readonly INatilleraRepositorie repositorio;
        private readonly IMapper mapper;
        public NatilleraBusiness(INatilleraRepositorie repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public bool BorrarNatillera(Guid natilleraId)
        {
            var natilleraBorrar = this.repositorio.Find(f => f.NatilleraId == natilleraId).Result;
            return this.repositorio.BorrarNatillera(natilleraBorrar).Result;
        }

        public bool GuardarNatillera(NatilleraENegocio natillera)
        {
            var natilleraEntity = this.mapper.Map<NatilleraEntity>(natillera);
            bool result = this.repositorio.GuardarNatillera(natilleraEntity).Result;
            return result;
        }

        public IEnumerable<NatilleraENegocio> ObtenerNatilleras()
        {
            var result = this.repositorio.ObtenerNatilleras().Result;
            var natillera= this.mapper.Map<List<NatilleraENegocio>>(result);

            return natillera;
        }
    }
}
