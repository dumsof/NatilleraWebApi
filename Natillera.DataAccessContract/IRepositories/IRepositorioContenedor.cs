namespace Natillera.DataAccessContract.IRepositories
{
    public interface IRepositorioContenedor
    {
        INatilleraRepositorie Natillera { get; }

        void Save();
    }
}
