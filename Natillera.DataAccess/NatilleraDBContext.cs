namespace Natillera.DataAccess
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract;
    using Natillera.DataAccessContract.Entidades;
    using System;

    public class NatilleraDBContext : IdentityDbContext<ApplicationUser>, INatilleraDBContext
    {
        //cuando se hereda de IdentityDbContext<ApplicationUser>, se crean las tablas para 
        //el manejo de usuarios.
        /// <summary>
        /// Initializes a new instance of the <see cref="AplicationDbContext"/> class.
        /// </summary>
        /// <param name="opcion">The opcion<see cref="DbContextOptions{AplicationDbContext}"/></param>
        public NatilleraDBContext(DbContextOptions opcion) : base(opcion)
        {
        }

        public DbSet<Natilleras> Natilleras { get; set; }

        public DbSet<TiposDocumentos> TiposDocumentos { get; set; }

        public DbSet<Prestamos> Prestamos { get; set; }

        public DbSet<ActividadesRecaudos> ActividadesRecaudos { get; set; }

        public DbSet<Socios> Socios { get; set; }

        public DbSet<NatilleraSocios> NatilleraSocios { get; set; }

        public DbSet<CuotasPrestamos> CuotasPrestamos { get; set; }

        public DbSet<CuotasSocios> CuotasSocios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ActividadesRecaudos>().Property(x => x.ActividadRecaudoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CuotasPrestamos>().Property(x => x.CuotaPrestamoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CuotasSocios>().Property(x => x.CuotaSocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Natilleras>().Property(x => x.NatilleraId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<NatilleraSocios>().Property(x => x.NatilleraSocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Prestamos>().Property(x => x.PrestamoId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Socios>().Property(x => x.SocioId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TiposDocumentos>().Property(x => x.TipoDocumentoId).HasDefaultValueSql("NEWID()");

            ///controlar la concurrencia, se valida esta propiedad en el token.
            ///Tema pagina 2272 pdf core 2.2
            modelBuilder.Entity<Natilleras>().Property(p => p.RowVersion).IsConcurrencyToken();

            //para esta columna por defecto se crea la fecha y hora en la cual se guarda la información
            modelBuilder.Entity<Natilleras>().Property(p => p.RowCreated).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

            modelBuilder.Entity<Natilleras>().Property(p => p.RowUpdated).HasDefaultValueSql("GetDate()").ValueGeneratedOnAddOrUpdate();
        }
    }
}
