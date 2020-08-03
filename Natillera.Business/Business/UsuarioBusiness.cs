namespace Natillera.Business.Business
{
    using AutoMapper;
    using Natillera.BusinessContract.EntidadesBusiness.Usuario;
    using Natillera.BusinessContract.IBusiness;
    using Natillera.DataAccessContract.IRepositories;  
    using System.Threading.Tasks;  
    using Natillera.DataAccessContract.Entidades;
    using System;
    using System.Collections.Generic;

    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepositorie usuarioRepositorio;
        private readonly ISocioRepositorie socioRepositorio;
        private readonly IMapper mapper;

        public UsuarioBusiness(IUsuarioRepositorie usuarioRepositorio, ISocioRepositorie socioRepositorio, IMapper mapper)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.socioRepositorio = socioRepositorio;
            this.mapper = mapper;
        }


        public async Task<bool> DeleteUsuarioAsync(string usuarioId)
        {
            bool estadoTransaccion = await this.usuarioRepositorio.DeleteUsuarioAsync(usuarioId);

            return estadoTransaccion;
        }

        public async Task<bool> EditarUsuarioAsync(UsuarioENegocio usuario)
        {
            bool estadoTransaccion = await this.usuarioRepositorio.EditarUsuarioAsync(this.mapper.Map<Usuario>(usuario));

            return estadoTransaccion;
        }

        public async Task<UsuarioENegocio> GuardarUsuarioAsync(UsuarioENegocio usuario)
        {
            var existeUsuario = await this.usuarioRepositorio.ExisteUsuarioAsync(this.mapper.Map<Usuario>(usuario));

            if (existeUsuario)
            {
                return new UsuarioENegocio();
            }
            else
            {                
                var socioId = await this.socioRepositorio.GuardarSocioAsync(this.mapper.Map<SocioEntity>(usuario));
                var resultUsuario = await this.usuarioRepositorio.GuardarUsuarioAsync(this.mapper.Map<Usuario>(usuario), socioId);

                return this.mapper.Map<UsuarioENegocio>(resultUsuario);
            }
        }

        public async Task<UsuarioENegocio> ObtenerUsuarioPorNombreAsync(string nombreUsuario)
        {
            var resultUsuario = await this.usuarioRepositorio.ObtenerUsuarioAsync(nombreUsuario);

            var usuario = this.mapper.Map<UsuarioENegocio>(resultUsuario);

            return usuario;
        }

        public async Task<IEnumerable<UserENegocio>> ObtenerUsuariosAsync()
        {
        

            var resultUsuario = await this.usuarioRepositorio.ObtenerUsuariosAsync();

            var usuario =  this.mapper.Map<List<UserENegocio>>(resultUsuario);

            return usuario;
        }

        public async Task<bool> UsuarioEsValidoAsync(UsuarioENegocio usuario)
        {
            var result = this.mapper.Map<Usuario>(usuario);

            bool estadoTransaccion = await this.usuarioRepositorio.UsuarioEsValidoAsync(this.mapper.Map<Usuario>(usuario));

            return estadoTransaccion;
        }
    }
}
