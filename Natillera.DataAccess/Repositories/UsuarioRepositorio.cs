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
                //Cedula = usuario.Cedula,
                //Nombres = usuario.Nombres,
                //PrimerApellido = usuario.PrimerApellido,
                //SegundoApellido = usuario.SegundoApellido,
                //Celular = usuario.Celular,
                //PhoneNumber = usuario.Telefono,
                //Direccion = usuario.Direccion
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

                return this.ObtenerUsuario(user);               
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
            var usuario = from u in _userManager.Users.ToList()
                          join s in this.repositorioContexto.Socios on u.SocioId equals s.SocioId
                          select new Usuarios
                          {
                              Id = u.Id,
                              Cedula = s.NumeroDocumento,
                              Nombres = s.Nombres,
                              PrimerApellido =s.PrimerApellidos,
                              SegundoApellido = s.SegundoApellidos,
                              Celular = s.Celular,
                              Telefono = s.Telefono,
                              Direccion = s.Direccion,
                              Email = u.Email,
                              Password = u.PasswordHash
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

        public async Task<bool> EditarUsuarioAsync(Usuarios usuario)
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

        private Usuarios ObtenerUsuario(ApplicationUser user)
        {           
            var socio = this.repositorioContexto.Socios.FirstOrDefault(c => c.Email.ToLower().Trim() == user.Email.ToLower().Trim());
           
            return new Usuarios
            {
                Id = user.Id,
                Cedula = socio.NumeroDocumento,
                Nombres = socio.Nombres,
                PrimerApellido = socio.PrimerApellidos,
                SegundoApellido = socio.SegundoApellidos,
                Celular = socio.Celular,
                Telefono = socio.Telefono,
                Direccion = socio.Direccion,
                Email = user.Email,
                Password = user.PasswordHash
            };
        }
    }
}
