namespace Natillera.DataAccessContract.IRepositories
{
    public interface IRepositorioContenedor
    {
        INatilleraRepositorie Natillera { get; }

        //IUsuarioRepositorie Usuario { get; }

        void Save();
    }
}
