namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NatilleraSocioEntity : Entity
    {
        [Key]
        public Guid NatilleraSocioId { get; set; }

        public Guid NatilleraId { get; set; }

        [ForeignKey("NatilleraId")]
        public NatilleraEntity Natilleras { get; set; }

        public Guid SocioId { get; set; }

        [ForeignKey("SocioId")]
        public SocioEntity Socios { get; set; }
    }
}
