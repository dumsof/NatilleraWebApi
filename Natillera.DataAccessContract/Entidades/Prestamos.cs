namespace Natillera.DataAccessContract.Entidades
{
    using System;   
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Prestamos : Entity
    {
        [Key]
        public Guid PrestamoId { get; set; }

        /// <summary>
        /// relacion de muchos a uno con la tabla socios.
        /// un prestamo debe tener un socio que solicita el prestamo.
        /// </summary>
        public Guid SocioId { get; set; }

        [ForeignKey("SocioId")]
        public SociosEntity Socios { get; set; }

        /// <summary>
        /// dia en el cual se realiza la entrega de la plata.
        /// </summary>
        public DateTime FechaDesembolso { get; set; }

        /// <summary>
        /// valor total que tiene guardado el socio en el momento de realizar el prestamo.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorCuotasNatillaActual { get; set; }

        /// <summary>
        /// valor el cual se esta prestando.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPrestado { get; set; }
        /// <summary>
        /// porcentaje que se le aplica al valor o monto que se esta prestando.
        /// </summary>
        public int PorcentajeInteres { get; set; }

        /// <summary>
        /// almacena la informacion de la persona que debe pagar el prestamo
        /// </summary>
        [StringLength(250)]
        public string ResponsablePagoPrestamo { get; set; }       
    }
}
