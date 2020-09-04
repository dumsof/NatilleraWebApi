namespace Natillera.AplicationContract.Models
{
    using System;

    public class AuditoriaAplication
    {
        public DateTime RowCreated { get; set; }        
        public byte[] RowVersion { get; set; }
    }
}