namespace Natillera.AplicationContract.IServices
{
    using Natillera.AplicationContract.Models;
    using Natillera.Business.Models;

    public interface INatilleraServices
    {
        Respuesta GuardarNatillera(Natillera natillera);

        RespuestaObtenerNatillera ObtenerNatilleras();
    }
}
