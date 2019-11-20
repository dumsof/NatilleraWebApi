namespace Natillera.DataAccess.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Threading.Tasks;

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



        public UsuarioRepositorio(UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
             NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Usuarios> GuardarUsuarioAsync(Usuarios usuario)
        {

            var user = new ApplicationUser { UserName = usuario.Email, Email = usuario.Email, };
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
                return usuario;
            }
            return null;
        }

        public async Task<bool> ExisteUsuario(Usuarios usuario)
        {
            var registrosAspNetUser = await _userManager.FindByNameAsync(usuario.Email);
            return registrosAspNetUser != null;
        }
    }
}
