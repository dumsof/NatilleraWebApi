namespace NatilleraWebApi.Models
{
    using Newtonsoft.Json;

    public class MensajeExeption
    {
        public int codigo { get; set; }
        public string Mensaje { get; set; }

        public string Exception { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
