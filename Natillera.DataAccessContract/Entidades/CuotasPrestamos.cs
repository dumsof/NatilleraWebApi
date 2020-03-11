namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CuotasPrestamos : Entity
    {
        [Key]
        public Guid CuotaPrestamoId { get; set; }

        /// <summary>
        /// la cuota a que prestamo pertenece
        /// </summary>
        public Prestamos Prestamos { get; set; }

        /// <summary>
        /// valor de la cuota sin cargos
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorCuota { get; set; }

        /// <summary>
        /// valor que contiene solo el interes
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorInteres { get; set; }

        /// <summary>
        /// fecha en la cual se debe realizar el pago
        /// </summary>
        public DateTime FechaEsperaPago { get; set; }

        /// <summary>
        /// fecha cuando se aplican los dias de gracia, limite para pagar sin mora.
        /// </summary>
        public DateTime FechaLimitePago { get; set; }


        /// <summary>
        /// dias despues que se cumple o se pasa la fecha limite de pago.
        /// </summary>
        public int DiasMora { get; set; }

        /// <summary>
        /// valor que se cobra a los dias que se demoran para el pago de las cuotas, esto despues del limite de pago.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDiasMora { get; set; }


        /// <summary>
        /// valor que contiene la suma del interes y el valor de la cuota.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorNetoPagoCuota { get; set; }
    }
}
