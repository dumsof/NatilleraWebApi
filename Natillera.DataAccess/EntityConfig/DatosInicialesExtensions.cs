namespace Natillera.DataAccess.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;
    using System;

    public static class DatosInicialesExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposDocumentos>().HasData(
                new TiposDocumentos { TipoDocumentoId = Guid.NewGuid(), Descripcion = "Cédula" },
                new TiposDocumentos { TipoDocumentoId = Guid.NewGuid(), Descripcion = "Tarjeta de Identidad" },
                new TiposDocumentos { TipoDocumentoId = Guid.NewGuid(), Descripcion = "Pasaporte" }
            );
        }

        public static void DatosPorDefectoTablas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadesRecaudos>().Property(x => x.ActividadRecaudoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CuotasPrestamos>().Property(x => x.CuotaPrestamoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CuotasSocios>().Property(x => x.CuotaSocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Natilleras>().Property(x => x.NatilleraId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<NatilleraSocios>().Property(x => x.NatilleraSocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Prestamos>().Property(x => x.PrestamoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Socios>().Property(x => x.SocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TiposDocumentos>().Property(x => x.TipoDocumentoId).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Menus>().Property(x => x.MenuId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MenuSubMenu>().Property(x => x.SubMenuId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MenuPermisos>().Property(x => x.MenuPermisoId).HasDefaultValueSql("NEWID()");
        }
    }
}
