namespace Natillera.Business.Models
{
    using System;
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


        /// <summary>
        /// indica cuando se debe iniciar con el pago de la cuota para cada uno de los socios.
        /// </summary>     
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        //[RegularExpression(@"(19|20)\d\d([- /.])(0[1-9]|1[012])\2(0[1-9]|[12][0-9]|3[01])", ErrorMessage = "El campo {0} tiene formato invalidao, formato  esperado yyyy-MM-dd")]
        public DateTime FechaInicioPagoCuota { get; set; }

        /// <summary>
        /// tipo de pago si es mensual o quincenal o lo que se quiera parametrizar
        /// </summary>             
        public int TipoPago { get; set; }

        /// <summary>
        /// es el valor de la cuota que debe dar cada socio.
        /// </summary>      
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        public decimal ValorCuotaPagar { get; set; }

        /// <summary>
        /// valor que se cobra si hay demora en el pago
        /// </summary>    
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]
        public decimal ValorMoraPagar { get; set; }

        /// <summary>
        /// dias que tiene el socio antes de aplicar el calculo del valor de la mora.
        /// </summary>             
        public int DiasGraciaMora { get; set; }

        /// <summary>
        /// si es falso el valor mora sera por cada dia, si es verdadero sin importar los dias que se pase del pago
        /// el valor sera el mismo.
        /// </summary>
        public bool ValorMoraDiaFijo { get; set; }

        /// <summary>
        /// no puede ser mayor que 12 cuotas, se calcula partiendo de el mes que los
        /// socios debe empezar con el pago de las cuotas.
        /// </summary>            
        [Required(ErrorMessage = "El campo {0} es requerido, por favor verifique.")]     
        public int NumeroCuotas { get; set; }
    }
}
