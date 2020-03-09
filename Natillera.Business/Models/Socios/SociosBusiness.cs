﻿namespace Natillera.Business.Models
{
    using global::Natillera.DataAccessContract.Entidades;
    using System;

    public class SociosBusiness
    {
        public int SocioId { get; set; }

        
        public string NumeroDocumento { get; set; }

       
        public DateTime FechaNacimiento { get; set; }

        
        public string Nombres { get; set; }

       
        public string PrimerApellidos { get; set; }

       
        public string SegundoApellidos { get; set; }

       
        public string Telefono { get; set; }

       
        public string Celular { get; set; }

       
        public string Direccion { get; set; }

     
        public string Email { get; set; }

        //propiedades que se utilizan para las relaciones
        /*Relacion uno a uno con el tipo de documento*/
        public TiposDocumentos TipoDocumento { get; set; }
    }
}