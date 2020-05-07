namespace Natillera.DataAccess.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System;

    public class UsuarioRepositorio : RepositoryBase<Usuario>, IUsuarioRepositorie
    {
        /// <summary>
        /// Defines the _userManager
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Defines the _signInManager
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly NatilleraDBContext repositorioContexto;


        public UsuarioRepositorio(UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
             NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.repositorioContexto = repositorioContexto;
        }

        public async Task<Usuario> GuardarUsuarioAsync(Usuario usuario, Guid socioId)
        {
            var user = new ApplicationUser
            {
                UserName = usuario.Email,
                Email = usuario.Email,
                SocioId = socioId
            };
            await _userManager.CreateAsync(user, usuario.Password);

            return usuario;
        }

        public async Task<bool> UsuarioEsValidoAsync(Usuario usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, true, false);

            return result.Succeeded;
        }

        public async Task<string> ExisteUsuarioAsync(Usuario usuario)
        {
            var registrosAspNetUser = await _userManager.FindByNameAsync(usuario.Email);

            return registrosAspNetUser?.SocioId.ToString();
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            var usuario = from u in _userManager.Users.ToList()
                          select new Usuario
                          {
                              Id = u.Id,
                              SocioId = u.SocioId,
                              NombreUsuario = u.UserName,
                              Email = u.Email,
                              Password = u.PasswordHash,
                          };

            return await Task.Run(() =>
            {
                return usuario;
            });
        }

        public async Task<bool> DeleteUsuarioAsync(string usuarioId)
        {
            var registrosAspNetUser = await _userManager.FindByIdAsync(usuarioId);
            var result = await _userManager.DeleteAsync(registrosAspNetUser);

            return result.Succeeded;
        }

        public async Task<bool> EditarUsuarioAsync(Usuario usuario)
        {
            var userTemp = await _userManager.FindByIdAsync(usuario.Id);


            //Id = usuario.Id,
            //UserName = usuario.Email,
            //Email = usuario.Email,
            //userTemp.Cedula = usuario.Cedula;
            //userTemp.Nombres = usuario.Nombres;
            //userTemp.PrimerApellido = usuario.PrimerApellido;
            //userTemp.SegundoApellido = usuario.SegundoApellido;
            //userTemp.Celular = usuario.Celular;
            //userTemp.PhoneNumber = usuario.Telefono;
            //userTemp.Direccion = usuario.Direccion;

            var result = await _userManager.UpdateAsync(userTemp);

            return result.Succeeded;
        }

        public async Task<Usuario> ObtenerUsuario(string email)
        {
            return await Task.Run(() =>
            {
                var usuario = _userManager.Users.AsEnumerable().First(c => c.Email.ToLower().Trim() == email.ToLower().Trim());

                return new Usuario
                {
                    Id = usuario.Id,
                    NombreUsuario = usuario.UserName,
                    Email = usuario.Email,
                    Password = usuario.PasswordHash
                };
            });
        }
    }
}
