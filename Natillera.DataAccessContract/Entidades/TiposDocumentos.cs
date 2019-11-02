namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TiposDocumentos
    {
        [Key]
        public int TipoDocumentoId { get; set; }


        [StringLength(200)]
        public String Descripcion { get; set; }
    }
}
