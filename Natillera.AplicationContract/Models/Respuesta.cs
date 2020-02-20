namespace Natillera.AplicationContract.Models
{
    using Natillera.CrossClothing.Mensajes.Message;

    public class Respuesta
    {
        public bool EstadoTransaccion { get; set; }
        public Mensaje Mensaje { get; set; }
    }
}
