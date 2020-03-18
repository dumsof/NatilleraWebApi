namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Roles;
    using Natillera.Business.Models.Roles;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;
    using System.Threading.Tasks;

    public class RolesServices : IRolesServices
    {
        private readonly IRolesRepositorio rolesRepositorie;

        public RolesServices(IRolesRepositorio rolesRepositorie)
        {
            this.rolesRepositorie = rolesRepositorie;
        }

        public async Task<Respuesta> DeleteRolAsync(string rolesId)
        {
            bool estadoTransaccion = await this.rolesRepositorie.DeleteRolAsync(rolesId);
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> EditarRolAsync(RolesBusiness rol)
        {
            bool estadoTransaccion = await this.rolesRepositorie.EditarRolAsync(null);

            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> GuardarRolAsync(RolesBusiness rol)
        {
            int codigoMensaje = 0;
            bool estadoTransaccion = false;
            if (await this.rolesRepositorie.ExisteRolAsync(rol.Id))
            {
                codigoMensaje = MessageCode.Message0002;
            }
            else
            {
                await this.rolesRepositorie.GuardarRolAsync(RolesMapper.RolesEntityMap(rol));
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
            var respuesta = await this.rolesRepositorie.ObtenerRolesAsync();

            return new RespuestaObtenerRoles
            {
                Roles = RolesMapper.RolesEntityMap(respuesta),
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
