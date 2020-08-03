namespace Natillera.AplicationContract.Models.TipoDocumento
{  
    using System.Collections.Generic;

    public class RespuestaTiposDocumento : Respuesta
    {
        public IEnumerable<TipoDocumentoAplication> TipoDocumentos { get; set; }
    }
}
