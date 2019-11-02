namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.IRepositories;

    /// <summary>
    /// patron repositorio, se aplica un contenedor o una sola area de trabajo, con el fin de poder inyectar todos los elementos 
    /// en una sola transacción cuando se llama al metodo Save.
    /// </summary>
    public class RepositorioContenedor : IRepositorioContenedor
    {
        private readonly NatilleraDBContext context;

        private INatilleraRepositorie natillera;

        public RepositorioContenedor(NatilleraDBContext context)
        {
            this.context = context;
        }

        public INatilleraRepositorie Natillera
        {
            get
            {
                if (this.natillera == null)
                {
                    this.natillera = new NatilleraRepositorio(this.context);
                }

                return this.natillera;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
