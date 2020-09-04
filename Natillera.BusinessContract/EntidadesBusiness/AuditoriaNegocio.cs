namespace Natillera.BusinessContract.EntidadesBusiness
{
    using System;

    public class AuditoriaNegocio
    {
        public DateTime RowCreated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}