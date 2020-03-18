namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System.Collections.Generic;
    using System.Linq;

    public class SociosRepositorio : RepositoryBase<Socios>, ISociosRepositorie
    {
        private readonly NatilleraDBContext repositorioContexto;

        public SociosRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            this.repositorioContexto = repositorioContexto;
        }

        public ICollection<Socios> ObtenerSocios()
        {
            var socios = (from s in this.repositorioContexto.Socios
                         join t in this.repositorioContexto.TiposDocumentos on s.TipoDocumentoId equals t.TipoDocumentoId
                         select new Socios
                         {
                                Celular=s.Celular,
                                 Nombres=s.Nombres,
                                  TipoDocumentoId=s.TipoDocumentoId
                                  
                         }).ToList();

            return socios;
        }
    }
}
