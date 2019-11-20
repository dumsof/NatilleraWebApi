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

        private readonly IRepositorioContenedor repositorio;

        private readonly IUsuarioRepositorie usuarioRepositorie;

        public UsuarioServices(IRepositorioContenedor repositorio, IUsuarioRepositorie usuarioRepositorie)
        {
            this.repositorio = repositorio;
            this.usuarioRepositorie = usuarioRepositorie;
        }

        public async Task<Respuesta> GuardarUsuarioAsync(Usuario usuario)
        {
            Message message = null;
            bool estadoTransaccion = false;
            if (await this.usuarioRepositorie.ExisteUsuario(UsuarioMapper.UsuarioEntityMap(usuario)))
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
