namespace Natillera.DataAccess
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract;
    using Natillera.DataAccessContract.Entidades;

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

            ///controlar la concurrencia, se valida esta propiedad en el token.
            ///Tema pagina 2272 pdf core 2.2
            modelBuilder.Entity<Natilleras>().Property(p => p.RowVersion).IsConcurrencyToken();
        }
    }
}
