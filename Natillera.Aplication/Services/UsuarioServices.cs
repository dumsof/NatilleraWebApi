namespace Natillera.Aplication.Services
{
    using AutoMapper;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Usuario;
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.CrossClothing.Mensajes.Message;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioBusiness usuarioBusiness;

        private readonly IMapper mapper;

        public UsuarioServices(IUsuarioBusiness usuarioBusiness, IMapper mapper)
        {
            this.usuarioBusiness = usuarioBusiness;
            this.mapper = mapper;
        }

        public async Task<Respuesta> DeleteUsuarioAsync(string usuarioId)
        {
            bool estadoTransaccion = await this.usuarioBusiness.DeleteUsuarioAsync(usuarioId);
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> EditarUsuarioAsync(UsuarioAplication usuario)
        {
            bool estadoTransaccion = await this.usuarioBusiness.EditarUsuarioAsync(this.mapper.Map<UsuarioENegocio>(usuario));

            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> GuardarUsuarioAsync(UsuarioAplication usuario)
        {
            int codigoMensaje = 0;
            bool estadoTransaccion = false;
            var usuarioGuardado = await this.usuarioBusiness.GuardarUsuarioAsync(this.mapper.Map<UsuarioENegocio>(usuario));
            if (usuarioGuardado?.Id == null)
            {
                codigoMensaje = MessageCode.Message0002;
            }
            else
            {
                codigoMensaje = MessageCode.Message0000;
                estadoTransaccion = true;
            }
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(codigoMensaje).Mensaje
            };
        }

        public async Task<RespuestaObtenerUsuario> ObtenerUsuariosAsync()
        {
            var respuesta = await this.usuarioBusiness.ObtenerUsuariosAsync();

            return new RespuestaObtenerUsuario
            {
                Usuarios = this.mapper.Map<List<UserAplication>>(respuesta),
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
