namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NatilleraSocios : Entity
    {
        [Key]
        public Guid NatilleraSocioId { get; set; }

        public Guid NatilleraId { get; set; }

        [ForeignKey("NatilleraId")]
        public Natilleras Natilleras { get; set; }

        public Guid SocioId { get; set; }

        [ForeignKey("SocioId")]
        public Socios Socios { get; set; }
    }
}
