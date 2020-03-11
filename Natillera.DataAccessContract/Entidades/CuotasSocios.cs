namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CuotasSocios : Entity
    {
        [Key]
        public Guid CuotaSocioId { get; set; }

        /// <summary>
        /// relacion de muchos a uno con la tabla socios.
        /// solo se deben cargar los socios que hacen parte de la natillera.
        /// </summary>
        public virtual Socios Socios { get; set; }

        /// <summary>
        /// fecha a la cual pertenece el pago de la cuota.
        /// </summary>
        public DateTime FechaPagoCuota { get; set; }

        /// <summary>
        /// valor por defecto que se debe pagar segun lo parametrizado para la natillera
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorCuota { get; set; }

        /// <summary>
        /// valor que se calcula segun las politicas de la natillera
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorMulta { get; set; }

        /// <summary>
        /// valor total despues de sumar el valor de la cuota y valor de la multa.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotalCuota { get; set; }

        //RELACIONES
        /// <summary>
        /// se selecciona la natillera para cargar los socios que pertenecen a la misma.
        /// </summary>
        public virtual Natilleras Natilleras { get; set; }
    }
}
