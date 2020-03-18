
namespace Natillera.DataAccess.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;

    public static class MenuSubMenuConfig
    {
        public static void MenuSubMenuRelacionTabla(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuSubMenu>().Property(x => x.SubMenuId).HasDefaultValueSql("NEWID()");

          
        }
    }
}
