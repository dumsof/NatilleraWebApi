namespace Natillera.DataAccessContract.Entidades
{
    using System;    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MenuSubMenu
    {
        [Key]
        public Guid SubMenuId { get; set; }

        public string DescripcionSubMenu { get; set; }

        public string RutaUrlSubMenu { get; set; }

        public int OrdenamientoSubMenu { get; set; }

        //muchos sub menu pueden pertenecer a un menu.
        public Guid MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menus Menus { get; set; }
    }
}
