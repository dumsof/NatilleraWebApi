namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NatilleraSocios : Entity
    {
        [Key]
        public Guid NatilleraSocioId { get; set; }

        public virtual Natilleras Natilleras { get; set; }

        public virtual Socios Socios { get; set; }
    }
}
