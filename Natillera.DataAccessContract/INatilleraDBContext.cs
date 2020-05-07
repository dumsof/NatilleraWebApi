namespace Natillera.DataAccessContract
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;

    public interface INatilleraDBContext
    {
        DbSet<NatilleraEntity> Natilleras { get; set; }

        DbSet<TipoDocumentoEntity> TiposDocumentos { get; set; }

        DbSet<PrestamoEntity> Prestamos { get; set; }

        DbSet<ActividadRecaudoEntity> ActividadesRecaudos { get; set; }

        DbSet<SocioEntity> Socios { get; set; }

        DbSet<NatilleraSocioEntity> NatilleraSocios { get; set; }

        DbSet<CuotaPrestamoEntity> CuotasPrestamos { get; set; }

        DbSet<CuotaSocioEntity> CuotasSocios { get; set; }

        DbSet<MenuEntity> Menus { get; set; }

        DbSet<MenuSubMenuEntity> MenuSubMenu { get; set; }

        DbSet<MenuPermisoEntity> MenuPermisos { get; set; }

    }
}
