namespace Natillera.DataAccessContract.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Socios : Entity
    {
        [Key]
        public int SocioId { get; set; }

        [StringLength(20)]
        public string NumeroDocumento { get; set; }

        [StringLength(200)]
        public string Nombres { get; set; }

        [StringLength(250)]
        public string Apellidos { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string Celular { get; set; }

        [StringLength(250)]
        public string Direccion { get; set; }

        [StringLength(150)]
        public string CorreoElectronico { get; set; }

        //propiedades que se utilizan para las relaciones
        /*Relacion uno a uno con el tipo de documento*/
        public virtual TiposDocumentos TiposDocumentos { get; set; }

        //relacion un socio puede pertenecer a diferentes natilleras
        public ICollection<NatilleraSocios> NatilleraSocios { get; set; }
    }
}
