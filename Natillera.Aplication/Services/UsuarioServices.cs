﻿namespace Natillera.Aplication.Services
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

        public async Task<Usuario> LogueoAsync(Usuario usuario)
        {
            var respuesta = await this.usuarioRepositorie.LogueoAsync(UsuarioMapper.UsuarioEntityMap(usuario));
            if (respuesta != null)
            {
                return usuario;
            }
            return null;
        }
    }
}
