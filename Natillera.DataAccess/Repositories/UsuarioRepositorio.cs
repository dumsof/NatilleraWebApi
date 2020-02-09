namespace Natillera.DataAccess.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public class UsuarioRepositorio : RepositoryBase<Usuarios>, IUsuarioRepositorie
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

        public async Task<Usuarios> GuardarUsuarioAsync(Usuarios usuario)
        {

            var user = new ApplicationUser
            {
                UserName = usuario.Email,
                Email = usuario.Email,
                Cedula = usuario.Cedula,
                Nombres = usuario.Nombres,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Celular = usuario.Celular,
                PhoneNumber = usuario.Telefono,
                Direccion = usuario.Direccion
            };
            var result = await _userManager.CreateAsync(user, usuario.Password);
            if (result.Succeeded)
            {
                return usuario;
            }

            return null;
        }

        public async Task<Usuarios> LogueoAsync(Usuarios usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(usuario.Email);

                return new Usuarios
                {
                    Id = user.Id,
                    Cedula = user.Cedula,
                    Nombres = user.Nombres,
                    PrimerApellido = user.PrimerApellido,
                    SegundoApellido = user.SegundoApellido,
                    Celular = user.Celular,
                    Telefono = user.PhoneNumber,
                    Direccion = user.Direccion,
                    Email = user.Email,
                    Password = user.PasswordHash
                };
            }
            return null;
        }

        public async Task<bool> ExisteUsuarioAsync(Usuarios usuario)
        {
            var registrosAspNetUser = await _userManager.FindByNameAsync(usuario.Email);
            //verificar la contraseña.
            //var passwordOK = await _userManager.CheckPasswordAsync(registrosAspNetUser, usuario.Password);


            return registrosAspNetUser != null;
        }

        public async Task<IEnumerable<Usuarios>> ObtenerUsuariosAsync()
        {
            var usuario = _userManager.Users.ToListAsync();
            return await Task.Run(() =>
            {
                return usuario.Result.Select(user => new Usuarios
                {
                    Id = user.Id,
                    Cedula = user.Cedula,
                    Nombres = user.Nombres,
                    PrimerApellido = user.PrimerApellido,
                    SegundoApellido = user.SegundoApellido,
                    Celular = user.Celular,
                    Telefono = user.PhoneNumber,
                    Direccion = user.Direccion,
                    Email = user.Email,
                    Password = user.PasswordHash
                });
            });
        }

        public async Task<bool> DeleteUsuarioAsync(string usuarioId)
        {
            var registrosAspNetUser = await _userManager.FindByIdAsync(usuarioId);
            var result = await _userManager.DeleteAsync(registrosAspNetUser);

            return result.Succeeded;
        }
    }
}
