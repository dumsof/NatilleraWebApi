namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;

    using System.Threading.Tasks;

    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepositorie usuarioRepositorie;

        public UsuarioServices(IUsuarioRepositorie usuarioRepositorie)
        {
            this.usuarioRepositorie = usuarioRepositorie;
        }

        public async Task<Respuesta> DeleteUsuarioAsync(string usuarioId)
        {
            bool estadoTransaccion = await this.usuarioRepositorie.DeleteUsuarioAsync(usuarioId);
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> EditarUsuarioAsync(Usuario usuario)
        {
            bool estadoTransaccion = await this.usuarioRepositorie.EditarUsuarioAsync(UsuarioMapper.UsuarioEntityMap(usuario));

            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }

        public async Task<Respuesta> GuardarUsuarioAsync(Usuario usuario)
        {
            int codigoMensaje = 0;
            bool estadoTransaccion = false;
            if (await this.usuarioRepositorie.ExisteUsuarioAsync(UsuarioMapper.UsuarioEntityMap(usuario)))
            {
                codigoMensaje = MessageCode.Message0002;
            }
            else
            {
                await this.usuarioRepositorie.GuardarUsuarioAsync(UsuarioMapper.UsuarioEntityMap(usuario));
                codigoMensaje = MessageCode.Message0000;
                estadoTransaccion = true;
            }
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Message(codigoMensaje).Mensaje
            };
        }

        public async Task<Usuario> LogueoAsync(UsuarioLogin usuarioLogin)
        {
            var respuesta = await this.usuarioRepositorie.LogueoAsync(UsuarioMapper.UsuarioEntityMap(usuarioLogin));
            if (respuesta != null)
            {
                return UsuarioMapper.UsuarioEntityMap(respuesta);
            }
            return null;
        }

        public async Task<RespuestaObtenerUsuario> ObtenerUsuariosAsync()
        {
            var respuesta = await this.usuarioRepositorie.ObtenerUsuariosAsync();

            return new RespuestaObtenerUsuario
            {
                Usuarios = UsuarioMapper.UsuarioEntityMap(respuesta),
                EstadoTransaccion = true,
                Mensaje = new Message(MessageCode.Message0000).Mensaje
            };
        }
    }
}
