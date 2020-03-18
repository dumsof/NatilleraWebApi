
namespace Natillera.DataAccess.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;

    public static class MenusConfig
    {
        public static void MenusRelacionTabla(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menus>().Property(x => x.MenuId).HasDefaultValueSql("NEWID()");           
        }
    }
}
