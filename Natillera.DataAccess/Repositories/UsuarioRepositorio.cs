namespace Natillera.DataAccess.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using System;

    public class UsuarioRepositorio : RepositoryBase<UsuariosEntity>, IUsuarioRepositorie
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

        public async Task<UsuariosEntity> GuardarUsuarioAsync(UsuariosEntity usuario, Guid socioId)
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

        public async Task<UsuariosEntity> LogueoAsync(UsuariosEntity usuario)
        {
            var result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(usuario.Email);

                return this.ObtenerUsuario(user);
            }

            return null;
        }

        public async Task<bool> ExisteUsuarioAsync(UsuariosEntity usuario)
        {
            var registrosAspNetUser = await _userManager.FindByNameAsync(usuario.Email);
            //verificar la contraseña.
            //var passwordOK = await _userManager.CheckPasswordAsync(registrosAspNetUser, usuario.Password);


            return registrosAspNetUser != null;
        }

        public async Task<IEnumerable<UsuariosEntity>> ObtenerUsuariosAsync()
        {
            var usuario = from u in _userManager.Users.ToList()
                          join s in this.repositorioContexto.Socios on u.SocioId equals s.SocioId
                          select new UsuariosEntity
                          {
                              Id = u.Id,
                              Cedula = s.NumeroDocumento,
                              Nombres = s.Nombres,
                              PrimerApellido = s.PrimerApellidos,
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

        public async Task<bool> EditarUsuarioAsync(UsuariosEntity usuario)
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

        private UsuariosEntity ObtenerUsuario(ApplicationUser user)
        {
            var socio = this.repositorioContexto.Socios.FirstOrDefault(c => c.Email.ToLower().Trim() == user.Email.ToLower().Trim());

            return new UsuariosEntity
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
