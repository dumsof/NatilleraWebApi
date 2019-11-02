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
        public static Natilleras NatilleraEntityMap(Natillera natillera)
        {
            return new Natilleras
            {
                NatilleraId = natillera.NatilleraId,
                Nombre = natillera.Nombre,
                Descripcion = natillera.Descripcion
            };
        }

        /// <summary>
        /// se transforma la informacion que envia la capa de repositorio a la entidad
        /// que necesita la capa de negocio que esta en el modelo del Bisness
        /// </summary>
        /// <param name="natilleraEntity"></param>
        /// <returns></returns>
        public static Natillera NatilleraMap(Natilleras natilleraEntity)
        {
            return new Natillera
            {
                NatilleraId = natilleraEntity.NatilleraId,
                Nombre = natilleraEntity.Nombre,
                Descripcion = natilleraEntity.Descripcion
            };
        }
    }
}
