namespace Natillera.DataAccessContract.Entidades
{
    using System.ComponentModel.DataAnnotations;

    //clase para mapear los campos de la base de datos.
    public class NatilleraEntity
    {
        [Key]
        public int IdNatillera { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        /// <summary>
        /// controlar la concurrencia.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
