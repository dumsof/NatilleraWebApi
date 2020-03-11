namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TiposDocumentos
    {
        [Key]
        public Guid TipoDocumentoId { get; set; }


        [StringLength(200)]
        public String Descripcion { get; set; }

        //public virtual Socios Socios { get; set; }
    }
}
