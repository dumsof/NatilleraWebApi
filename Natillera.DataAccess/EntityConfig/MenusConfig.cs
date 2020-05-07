
namespace Natillera.DataAccess.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;

    public static class MenusConfig
    {
        public static void MenusRelacionTabla(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuEntity>().Property(x => x.MenuId).HasDefaultValueSql("NEWID()");           
        }
    }
}
