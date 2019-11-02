namespace Natillera.Business.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// clase de negocio, la cual puede tener mas propiedades o menos que las clase de entity que serian
    /// iguales a las estructuras de la base de datos.
    /// </summary>
    public class Natillera
    {
        [DataType(DataType.Currency)]
        public int NatilleraId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener maximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        [StringLength(150, ErrorMessage = "El campo {0} debe contener maximo  {1} caracteres.")]
        public string Descripcion { get; set; }
    }
}
