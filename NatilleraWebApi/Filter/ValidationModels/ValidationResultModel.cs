namespace NatilleraWebApi.Filter.ValidationModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using LoggerService;
    /// <summary>
    /// Defines the <see cref="ValidationResultModel" />
    /// </summary>
    public class ValidationResultModel
    {
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Mensaje con la definicion del tipo de validacion, en este caso para los campos.
        /// </summary>
        private string TipoMensaje { get; }

        /// <summary>
        /// almacena los datos del nombre del campo y su respectiva validacion que no cumplio.
        /// </summary>
        private List<ValidationError> Errores { get; }

        public ValidationResultModel(ILoggerManager logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// DUM: Metodo que permite obtener o capturar las validaciones del models con sus mensajes de validación <see cref="ValidationResultModel"/> class.
        /// </summary>
        /// <param name="modelState">objeto donde se encuentra el nombre de la propiedad y el mensaje de validación<see cref="ModelStateDictionary"/></param>
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            TipoMensaje = "Validación de los Campos.";
            Errores = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();

            //DUM: tratas de registar cuando hay alguna validación
            if (Errores != null && Errores.Count > 0)
            {

                string mensajeValidacion = Errores.Select(c => c.MensajeValidacion).Aggregate((concat, str) => $"{concat}&{str}");
                _logger.LogError($"VALIDACIÓN ENTRADAS FRONT END:{mensajeValidacion}");
            }

        }
    }
}
