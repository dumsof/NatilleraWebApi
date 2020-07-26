namespace Natillera.DataAccess
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccess.EntityConfig;
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

        public DbSet<NatilleraEntity> Natilleras { get; set; }

        public DbSet<TipoDocumentoEntity> TiposDocumentos { get; set; }

        public DbSet<PrestamoEntity> Prestamos { get; set; }

        public DbSet<ActividadRecaudoEntity> ActividadesRecaudos { get; set; }

        public DbSet<SocioEntity> Socios { get; set; }

        public DbSet<NatilleraSocioEntity> NatilleraSocios { get; set; }

        public DbSet<CuotaPrestamoEntity> CuotasPrestamos { get; set; }

        public DbSet<CuotaSocioEntity> CuotasSocios { get; set; }

        public DbSet<MenuEntity> Menus { get; set; }

        public DbSet<MenuSubMenuEntity> MenuSubMenu { get; set; }

        public DbSet<MenuPermisoEntity> MenuPermisos { get; set; }

        public DbSet<TokenEntity> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //generar los datos iniciales.
            modelBuilder.Seed();

            //base.OnModelCreating(modelBuilder);

            modelBuilder.DatosPorDefectoTablas();
            modelBuilder.DatosPrincipalesLogueo();

            //Dum: se crea la relación entre tablas, socios depende de tipodocumentos x TipodDocumentoId
            //modelBuilder.MenusRelacionTabla();

            //modelBuilder.MenuSubMenuRelacionTabla();

            //modelBuilder.Entity<Socios>().HasOne<TiposDocumentos>().WithMany().HasForeignKey(p => p.TipoDocumentoId);


            ///controlar la concurrencia, se valida esta propiedad en el token.
            ///Tema pagina 2272 pdf core 2.2
            modelBuilder.Entity<NatilleraEntity>().Property(p => p.RowVersion).IsConcurrencyToken();

            //para esta columna por defecto se crea la fecha y hora en la cual se guarda la información
            modelBuilder.Entity<NatilleraEntity>().Property(p => p.RowCreated).HasDefaultValueSql("GetDate()").ValueGeneratedOnAdd();

            modelBuilder.Entity<NatilleraEntity>().Property(p => p.RowUpdated).HasDefaultValueSql("GetDate()").ValueGeneratedOnAddOrUpdate();

           


            base.OnModelCreating(modelBuilder);
        }
    }
}
