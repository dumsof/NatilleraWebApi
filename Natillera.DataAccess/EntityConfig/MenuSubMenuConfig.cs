
namespace Natillera.DataAccess.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;

    public static class MenuSubMenuConfig
    {
        public static void MenuSubMenuRelacionTabla(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuSubMenuEntity>().Property(x => x.SubMenuId).HasDefaultValueSql("NEWID()");

          
        }
    }
}
