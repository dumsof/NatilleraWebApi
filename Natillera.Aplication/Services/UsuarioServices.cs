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
            Message message;
            bool estadoTransaccion = await this.usuarioRepositorie.DeleteUsuarioAsync(usuarioId);
            message = new Message(MessageCode.Message0000);
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
            };
        }

        public async Task<Respuesta> EditarUsuarioAsync(Usuario usuario)
        {
            Message message;
            bool estadoTransaccion = await this.usuarioRepositorie.EditarUsuarioAsync(UsuarioMapper.UsuarioEntityMap(usuario));
            message = new Message(MessageCode.Message0000);
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
            };
        }

        public async Task<Respuesta> GuardarUsuarioAsync(Usuario usuario)
        {
            Message message;
            bool estadoTransaccion = false;
            if (await this.usuarioRepositorie.ExisteUsuarioAsync(UsuarioMapper.UsuarioEntityMap(usuario)))
            {
                message = new Message(MessageCode.Message0002);
            }
            else
            {
                await this.usuarioRepositorie.GuardarUsuarioAsync(UsuarioMapper.UsuarioEntityMap(usuario));
                message = new Message(MessageCode.Message0000);
                estadoTransaccion = true;
            }
            return new Respuesta
            {
                EstadoTransaccion = estadoTransaccion,
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
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
                EstadoTransaccion = true
            };
        }
    }
}
