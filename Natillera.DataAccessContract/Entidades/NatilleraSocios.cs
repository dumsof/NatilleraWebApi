namespace Natillera.DataAccessContract.Entidades
{
    using System.ComponentModel.DataAnnotations;

    public class NatilleraSocios : Entity
    {
        [Key]
        public int NatilleraSocioId { get; set; }

        public virtual Natilleras Natilleras { get; set; }

        public virtual Socios Socios { get; set; }
    }
}
