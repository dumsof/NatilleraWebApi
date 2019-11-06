namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;
    using Natillera.DataAccessContract.IRepositories;
    using System.Linq;

    public class UsuarioServices : IUsuarioServices
    {

        private readonly IRepositorioContenedor repositorio;

        public UsuarioServices(IRepositorioContenedor repositorio)
        {
            this.repositorio = repositorio;
        }

        public Respuesta GuardarUsuario(Usuario usuario)
        {
            Message message = new Message(MessageCode.Message0000);

            this.repositorio.Usuario.Create(UsuarioMapper.UsuarioEntityMap(usuario));
            this.repositorio.Save();

            return new Respuesta
            {
                Mensaje = new Mensaje
                {
                    Identificador = message.Code,
                    Titulo = message.Title,
                    Contenido = message.Text
                }
            };
        }

        public Usuario Logueo(Usuario usuario)
        {
            var respuesta = this.repositorio.Usuario.FindByCondition(c => c.Password == usuario.Password && c.Email.Trim() == usuario.Email.Trim()).FirstOrDefault();
            return UsuarioMapper.UsuarioEntityMap(respuesta);
        }
    }
}
