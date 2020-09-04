﻿namespace Natillera.DataAccessContract.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class Entity
    {
        /// <summary>
        /// controlar la concurrencia.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime RowCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// cuando el registro se actualiza se genera la fecha y hora.
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RowUpdated { get; set; } = DateTime.Now;

        /// <summary>
        /// controlar la concurrencia.
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
