namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    

    public class MenuPermisos
    {
        [Key]
        public Guid MenuPermisoId{ get; set; }

        [Column(TypeName = "NVARCHAR(128)")]       
        public string AspNetRolesId { get; set; }

        public Guid? SubMenuId { get; set; }
        [ForeignKey("SubMenuId")]
        public MenuSubMenu MenuSubMenu { get; set; }

        public bool Crear { get; set; }

        public bool Borrar { get; set; }

        public bool Actualizar { get; set; }

        public bool Ver { get; set; }
    }
}
