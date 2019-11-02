namespace Natillera.Aplication.Services
{
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;
    using Natillera.CrossClothing.Mensajes.Message;
    using Natillera.DataAccess.Mapper;  
    using Natillera.DataAccessContract.IRepositories;   

    public class NatilleraServices : INatilleraServices
    {
        private readonly IRepositorioContenedor repositorio;
        public NatilleraServices(IRepositorioContenedor repositorio)
        {
            this.repositorio = repositorio;
        }

        public Respuesta GuardarNatillera(Natillera natillera)
        {
            Message message = new Message(MessageCode.Message0000);

            this.repositorio.Natillera.Create(NatilleraMapper.NatilleraEntityMap(natillera));
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
    }
}
