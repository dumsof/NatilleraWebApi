﻿namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.AplicationContract.Models.Natillera;
    using System;

    public interface INatilleraServices
    {
        Respuesta GuardarNatillera(NatilleraAplication natillera);

        RespuestaObtenerNatillera ObtenerNatilleras();

        Respuesta BorrarNatillera(Guid natilleraId);
    }
}
