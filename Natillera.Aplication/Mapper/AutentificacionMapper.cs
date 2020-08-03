using AutoMapper;
using Natillera.AplicationContract.Models.Usuario;

namespace Natillera.Aplication.Mapper
{
    public class AutentificacionMapper : Profile
    {
        public AutentificacionMapper()
        {
            CreateMap<RequestUsuarioLogin, RequestUsuarioLoginPrueba>();
        }
    }
}
