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

        private ISocioRepositorie socios;

        private IUsuarioRepositorie usuario;

        private ITokensRepositorio tokens;

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

        public ISocioRepositorie Socios
        {
            get
            {
                if (this.socios == null)
                {
                    this.socios = new SocioRepositorio(this.context);
                }

                return this.socios;
            }
        }


        public ITokensRepositorio Tokens
        {
            get
            {
                if (this.tokens == null)
                {
                    this.tokens = new TokensRepositorio(this.context);
                }

                return this.tokens;
            }
        }

        //public IUsuarioRepositorie Usuario
        //{
        //    get
        //    {
        //        if (this.usuario == null)
        //        {
        //            this.usuario = new UsuarioRepositorio(this.context);
        //        }

        //        return this.usuario;
        //    }
        //}

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
