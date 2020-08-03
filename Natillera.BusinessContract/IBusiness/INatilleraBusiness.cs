namespace Natillera.BusinessContract.IBusiness
{
    using Natillera.BusinessContract.EntidadesBusiness.Natillera;
    using System;
    using System.Collections.Generic;

    public interface INatilleraBusiness
    {
        bool GuardarNatillera(NatilleraENegocio natillera);

        IEnumerable<NatilleraENegocio> ObtenerNatilleras();

        bool BorrarNatillera(Guid natilleraId);
    }
}
