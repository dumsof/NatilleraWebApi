namespace Natillera.DataAccess.Mapper
{
    using Natillera.Business.Models;
    using Natillera.DataAccessContract.Entidades;

    public static class NatilleraMapper
    {
        /// <summary>
        /// se tranforma la informacion del negocio a la entidad que necesita la capa de repositorio
        /// </summary>
        /// <param name="natillera"></param>
        /// <returns></returns>
        public static NatilleraEntity NatilleraEntityMap(Natillera natillera)
        {
            return new NatilleraEntity
            {
                NatilleraId = natillera.NatilleraId,
                Nombre = natillera.Nombre,
                Descripcion = natillera.Descripcion,
                NumeroCuotas = natillera.NumeroCuotas,
                DiasGraciaMora = natillera.DiasGraciaMora,
                FechaInicioPagoCuota = natillera.FechaInicioPagoCuota,
                TipoPago = natillera.TipoPago,
                ValorCuotaPagar = natillera.ValorCuotaPagar,
                ValorMoraDiaFijo = natillera.ValorMoraDiaFijo,
                ValorMoraPagar = natillera.ValorMoraPagar
            };
        }

        /// <summary>
        /// se transforma la informacion que envia la capa de repositorio a la entidad
        /// que necesita la capa de negocio que esta en el modelo del Bisness
        /// </summary>
        /// <param name="natilleraEntity"></param>
        /// <returns></returns>
        public static Natillera NatilleraMap(NatilleraEntity natilleraEntity)
        {
            return new Natillera
            {
                NatilleraId = natilleraEntity.NatilleraId,
                Nombre = natilleraEntity.Nombre,
                Descripcion = natilleraEntity.Descripcion,
                NumeroCuotas = natilleraEntity.NumeroCuotas,
                DiasGraciaMora = natilleraEntity.DiasGraciaMora,
                FechaInicioPagoCuota = natilleraEntity.FechaInicioPagoCuota,
                TipoPago = natilleraEntity.TipoPago,
                ValorCuotaPagar = natilleraEntity.ValorCuotaPagar,
                ValorMoraDiaFijo = natilleraEntity.ValorMoraDiaFijo,
                ValorMoraPagar = natilleraEntity.ValorMoraPagar
            };
        }
    }
}
