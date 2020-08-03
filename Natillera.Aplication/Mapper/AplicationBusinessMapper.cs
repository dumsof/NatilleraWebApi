namespace Natillera.Aplication.Mapper
{
    using AutoMapper;
    using Natillera.AplicationContract.Models.Socios;
    using Natillera.AplicationContract.Models.TipoDocumento;
    using Natillera.AplicationContract.Models.Usuario;
    using Natillera.BusinessContract.EntidadesBusiness.Socios;
    using Natillera.BusinessContract.EntidadesBusiness.TipoDocumento;
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;
    using Natillera.DataAccessContract.Entidades;

    public class AplicationBusinessMapper : Profile
    {
        public AplicationBusinessMapper()
        {
            CreateMap<RequestUsuarioLogin, UsuarioENegocio>();
            CreateMap<UsuarioENegocio, UsuarioAplication>();
            CreateMap<SocioENegocio, SocioAplication>();
            CreateMap<SocioAplication, SocioENegocio>();
            CreateMap<SocioENegocio, Usuario>();
            CreateMap<Usuario, SocioENegocio>();
            CreateMap<UsuarioAplication, UsuarioENegocio>();
            CreateMap<UserAplication, UserENegocio>();
            CreateMap<UserENegocio, UserAplication>();
            CreateMap<TipoDocumentoENegocio, TipoDocumentoAplication>();
            CreateMap<TipoDocumentoAplication, TipoDocumentoENegocio>();
        }
    }
}
