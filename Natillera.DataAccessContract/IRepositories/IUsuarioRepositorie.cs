﻿namespace Natillera.DataAccessContract.IRepositories
{
    using Natillera.DataAccessContract.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarioRepositorie : IRepositoryBase<Usuario>
    {
        Task<IEnumerable<Usuario>> ObtenerUsuariosAsync();

        Task<bool> EditarUsuarioAsync(Usuario usuario);

        Task<Usuario> GuardarUsuarioAsync(Usuario usuario, Guid socioId);

        Task<bool> UsuarioEsValidoAsync(Usuario usuario);

        Task<bool> ExisteUsuarioAsync(Usuario usuario);

        Task<bool> DeleteUsuarioAsync(string usuarioId);

        Task<Usuario> ObtenerUsuarioAsync(string nombreUsuario);

        Task<Usuario> ObtenerUsuariosIdUsuarioOIdSocioAsync(string usuarioIdidSocio);
    }
}
