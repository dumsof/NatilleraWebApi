namespace Natillera.DataAccess.EntityConfig
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;
    using System;

    public static class DatosInicialesExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumentoEntity>().HasData(
                new TipoDocumentoEntity { TipoDocumentoId = Guid.Parse("CEB36362-6EBB-4649-AE51-48EE9F60892A"), Descripcion = "Cédula" },
                new TipoDocumentoEntity { TipoDocumentoId = Guid.Parse("BA4B88FB-6AC5-4678-8DE6-95925728DC67"), Descripcion = "Tarjeta de Identidad" },
                new TipoDocumentoEntity { TipoDocumentoId = Guid.Parse("1E424D0F-622A-4BA4-9D11-AEF931D89239"), Descripcion = "Pasaporte" }
            );

            modelBuilder.Entity<SocioEntity>().HasData(
                new SocioEntity
                {
                    SocioId = Guid.Parse("f95ba36f-daa0-4b14-a142-51ec51cf7d91"),
                    Nombres = "Darwin",
                    PrimerApellidos = "Urrutia",
                    SegundoApellidos = "mosquera",
                    Celular = "3112343434",
                    Telefono = "2343434",
                    NumeroDocumento = "11803053",
                    Direccion = "Dirección",
                    Email = "dun34@hotmail.com",
                    FechaNacimiento = Convert.ToDateTime("1990-06-05"),
                    TipoDocumentoId = Guid.Parse("CEB36362-6EBB-4649-AE51-48EE9F60892A")
                }
            );
        }

        public static void DatosPorDefectoTablas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadRecaudoEntity>().Property(x => x.ActividadRecaudoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CuotaPrestamoEntity>().Property(x => x.CuotaPrestamoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CuotaSocioEntity>().Property(x => x.CuotaSocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<NatilleraEntity>().Property(x => x.NatilleraId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<NatilleraSocioEntity>().Property(x => x.NatilleraSocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PrestamoEntity>().Property(x => x.PrestamoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SocioEntity>().Property(x => x.SocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TipoDocumentoEntity>().Property(x => x.TipoDocumentoId).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<MenuEntity>().Property(x => x.MenuId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MenuSubMenuEntity>().Property(x => x.SubMenuId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<MenuPermisoEntity>().Property(x => x.MenuPermisoId).HasDefaultValueSql("NEWID()");
        }

        public static void DatosPrincipalesLogueo(this ModelBuilder modelBuilder)
        {
            const string ADMIN_ID = "38e606c8-7f9e-4158-a671-444992bd89f5";
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "dun34@hotmail.com",
                NormalizedUserName = "DUN34@HOTMAIL.COM",
                Email = "dun34@hotmail.com",
                NormalizedEmail = "DUN34@HOTMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAECokRB0Ykqax/BA+NyuGbiauAJ+X4Mcs1STYMpREdRcWXSLFDxcEtrLpGczPaZX6bw==",
                SecurityStamp = "DVJF5PLZA76QHHTNVSJYRF5NVCQTSRTQ",
                ConcurrencyStamp = "52de73a0-39c6-42fa-a5c5-4da232483486",
                SocioId = Guid.Parse("f95ba36f-daa0-4b14-a142-51ec51cf7d91")
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
