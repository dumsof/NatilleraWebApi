namespace Natillera.CrossClothing.Mensajes.Message
{
    public class Mensaje
    {
        public int Identificador { get; set; }
        public string Contenido { get; set; }
        public MessageType TipoMensaje { get; set; }
        public string Titulo { get; set; }
    }
}
