namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //clase para mapear los campos de la base de datos.
    public class NatilleraEntity : Entity
    {
        [Key]
        public Guid NatilleraId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        /// <summary>
        /// indica cuando se debe iniciar con el pago de la cuota para cada uno de los socios.
        /// </summary>     
        public DateTime FechaInicioPagoCuota { get; set; }

        /// <summary>
        /// tipo de pago si es mensual o quincenal o lo que se quiera parametrizar
        /// </summary>             
        public int TipoPago { get; set; }

        /// <summary>
        /// es el valor de la cuota que debe dar cada socio.
        /// </summary>      
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorCuotaPagar { get; set; }

        /// <summary>
        /// valor que se cobra si hay demora en el pago
        /// </summary>    
        [Column(TypeName = "decimal(18,2)")]
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
        public int NumeroCuotas { get; set; }

        ////RELACION
        ////una natillera puede tener muchas cuotas del socio
        //public ICollection<CuotasSocios> CuotasSocios { get; set; }

        ////relacion un socio puede pertenecer a diferentes natilleras
        //public ICollection<NatilleraSocios> NatilleraSocios { get; set; }
    }
}
