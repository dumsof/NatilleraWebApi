
namespace Natillera.Business.Mapper
{
    using AutoMapper;
    using Natillera.BusinessContract.EntidadesBusiness.Socios;
    using Natillera.BusinessContract.EntidadesBusiness.TipoDocumento;
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;
    using Natillera.DataAccessContract.Entidades;

    public class BusinessDataAccessMapper : Profile
    {
        public BusinessDataAccessMapper()
        {
            CreateMap<UsuarioENegocio, Usuario>();
            CreateMap<Usuario, UsuarioENegocio>();
            CreateMap<Socio, SocioENegocio>();
            CreateMap<SocioENegocio, Socio>();
            CreateMap<UsuarioENegocio, SocioEntity>();
            CreateMap<UserENegocio, Usuario>();
            CreateMap<Usuario, UserENegocio>();
            CreateMap<TipoDocumentoENegocio, TipoDocumentoEntity>();
            CreateMap<TipoDocumentoEntity, TipoDocumentoENegocio>();
        }
    }
}
