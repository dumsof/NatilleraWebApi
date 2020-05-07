namespace Natillera.DataAccessContract.IRepositories
{
    public interface IRepositorioContenedor
    {
        INatilleraRepositorie Natillera { get; }

        ISocioRepositorie Socios { get; }

        //IUsuarioRepositorie Usuario { get; }

        void Save();
        void Dispose();
    }
}
