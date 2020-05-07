namespace Natillera.DataAccess.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Natillera.DataAccessContract.Entidades;
    using Natillera.DataAccessContract.IRepositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SocioRepositorio : RepositoryBase<SocioEntity>, ISocioRepositorie
    {
        private readonly NatilleraDBContext repositorioContexto;

        public SocioRepositorio(NatilleraDBContext repositorioContexto) : base(repositorioContexto)
        {
            this.repositorioContexto = repositorioContexto;
        }

        public async Task<Guid> GuardarSocioAsync(SocioEntity socio)
        {
            var resultado = await this.AddAsync(socio);
            this.Save();
            return resultado.SocioId;
        }

        public async Task<IEnumerable<SocioEntity>> ObtenerSociosAsync()
        {
            var socios = await (from s in this.repositorioContexto.Socios
                                join t in this.repositorioContexto.TiposDocumentos on s.TipoDocumentoId equals t.TipoDocumentoId
                                select new SocioEntity
                                {
                                    Celular = s.Celular,
                                    Nombres = s.Nombres,
                                    TipoDocumentoId = s.TipoDocumentoId
                                }).ToListAsync();
            return socios;
        }

        public async Task<Socio> ObtenerSocioIdAsync(Guid socioId)
        {
            var socio = await (from s in this.repositorioContexto.Socios
                               join t in this.repositorioContexto.TiposDocumentos on s.TipoDocumentoId equals t.TipoDocumentoId
                               where s.SocioId == socioId
                               select new Socio
                               {
                                   SocioId = s.SocioId,
                                   NumeroDocumento = s.NumeroDocumento,
                                   Nombres = s.Nombres,
                                   PrimerApellidos = s.PrimerApellidos,
                                   SegundoApellidos = s.SegundoApellidos,
                                   FechaNacimiento = s.FechaNacimiento,
                                   Celular = s.Celular,
                                   Email = s.Email,
                                   Telefono = s.Telefono,
                                   Direccion = s.Direccion,
                                   TipoDocumentoId = s.TipoDocumentoId,
                                   TiposDocumentoDescripcion = t.Descripcion
                               }).FirstOrDefaultAsync();

            return socio;
        }
    }
}
