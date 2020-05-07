namespace Natillera.DataAccessContract.Entidades
{
    using System;  
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MenuEntity
    {
        [Key]
        public Guid MenuId { get; set; }       

        public string DescripcionMenu { get; set; }

        public string RutaUrlMenu { get; set; }

        public int OrdenamientoMenu { get; set; }            
    }
}
