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

        public async Task<bool> NoFueModificadoOtroUsuarioConcurrente(SocioEntity socio)
        {
            var socioActualizar = await this.repositorioContexto.Socios.FirstOrDefaultAsync(c => c.SocioId == socio.SocioId && c.RowVersion == socio.RowVersion);

            return socioActualizar != null;
        }

        public async Task<Guid> GuardarSocioAsync(SocioEntity socio)
        {
            socio.SocioId = Guid.NewGuid();
            var resultado = await this.AddAsync(socio);
            this.Save();
            return resultado.SocioId;
        }

        public async Task ActualizarSocioAsync(SocioEntity socio)
        {
            await this.UpdateAsync(socio);            
        }

        public async Task<IEnumerable<Socio>> ObtenerSociosAsync()
        {
            var socios = await (from s in this.repositorioContexto.Socios
                                join t in this.repositorioContexto.TiposDocumentos on s.TipoDocumentoId equals t.TipoDocumentoId
                                orderby s.RowUpdated descending
                                select new Socio
                                {
                                    SocioId = s.SocioId,
                                    Celular = s.Celular,
                                    Nombres = s.Nombres,
                                    TipoDocumentoId = s.TipoDocumentoId,
                                    Direccion = s.Direccion,
                                    Email = s.Email,
                                    FechaNacimiento = s.FechaNacimiento,
                                    NumeroDocumento = s.NumeroDocumento,
                                    PrimerApellidos = s.PrimerApellidos,
                                    SegundoApellidos = s.SegundoApellidos,
                                    Telefono = s.Telefono,
                                    TiposDocumentoDescripcion = t.Descripcion,
                                    RowCreated = s.RowCreated,
                                    RowVersion = s.RowVersion
                                }).ToListAsync();
            return socios;
        }

        public async Task<Socio> ObtenerSocioIdAsync(Guid socioId)
        {
            var socio = await (from s in this.repositorioContexto.Socios
                               join t in this.repositorioContexto.TiposDocumentos on s.TipoDocumentoId equals t.TipoDocumentoId
                               where s.SocioId == socioId
                               orderby s.RowUpdated descending
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
                                   TiposDocumentoDescripcion = t.Descripcion,
                                   RowCreated = s.RowCreated,
                                   RowVersion = s.RowVersion
                               }).FirstOrDefaultAsync();

            return socio;
        }

        public async Task<bool> DeleteSocioIdAsync(Guid socioId)
        {
            var socio = await this.Find(c => c.SocioId == socioId);
            await this.DeleteAsync(socio);

            return true;
        }

        public async Task<bool> DeleteSocioIdAsync(SocioEntity socio)
        {
            await this.DeleteAsync(socio);

            return true;
        }
    }
}