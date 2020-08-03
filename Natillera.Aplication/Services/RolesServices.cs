namespace Natillera.Aplication.Services
{
    using AutoMapper;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Roles;
    using Natillera.BusinessContract.EntidadesBusiness.Roles;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RolesServices : IRolesServices
    {
        private readonly IRolBusiness rolBusiness;
        private readonly IMapper mapper;

        public RolesServices(IRolBusiness rolBusiness, IMapper mapper)
        {
            this.rolBusiness = rolBusiness;
            this.mapper = mapper;
        }

        public async Task<Respuesta> DeleteRolAsync(string rolesId)
        {
            bool estadoTransaccion = await this.rolBusiness.DeleteRolAsync(rolesId);
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> EditarRolAsync(RolEAplication rol)
        {
            bool estadoTransaccion = await this.rolBusiness.EditarRolAsync(null);

            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> GuardarRolAsync(RolEAplication rol)
        {
            int codigoMensaje = 0;
            bool estadoTransaccion = false;
            if (await this.rolBusiness.ExisteRolAsync(rol.Id))
            {
                codigoMensaje = MessageCode.Message0002;
            }
            else
            {
                await this.rolBusiness.GuardarRolAsync(this.mapper.Map<RolENegocio>(rol));
                codigoMensaje = MessageCode.Message0000;
                estadoTransaccion = true;
            }
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(codigoMensaje).Mensaje
            };
        }

        public async Task<RespuestaObtenerRoles> ObtenerRolesAsync()
        {
            var respuesta = await this.rolBusiness.ObtenerRolesAsync();

            return new RespuestaObtenerRoles
            {
                Roles = this.mapper.Map<List<RolEAplication>>(respuesta),
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
