namespace Natillera.DataAccess.Repositories
{
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SociosRepositorio : RepositoryBase<SociosEntity>, ISociosRepositorie
    {
        private readonly NatilleraDBContext repositorioContexto;

        public SociosRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            this.repositorioContexto = repositorioContexto;
        }

        public async Task<Guid> GuardarSocioAsync(SociosEntity socio)
        {
            var resultado = await this.AddAsync(socio);
            this.Save();
            return resultado.SocioId ;
        }

        public ICollection<SociosEntity> ObtenerSocios()
        {
            var socios = (from s in this.repositorioContexto.Socios
                          join t in this.repositorioContexto.TiposDocumentos on s.TipoDocumentoId equals t.TipoDocumentoId
                          select new SociosEntity
                          {
                              Celular = s.Celular,
                              Nombres = s.Nombres,
                              TipoDocumentoId = s.TipoDocumentoId

                          }).ToList();

            return socios;
        }
    }
}
