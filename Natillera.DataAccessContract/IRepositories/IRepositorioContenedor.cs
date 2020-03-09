namespace Natillera.DataAccessContract.IRepositories
{
    public interface IRepositorioContenedor
    {
        INatilleraRepositorie Natillera { get; }

        ISociosRepositorie Socios { get; }

        //IUsuarioRepositorie Usuario { get; }

        void Save();
        void Dispose();
    }
}
