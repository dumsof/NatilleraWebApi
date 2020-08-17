namespace Natillera.CrossClothing.Mensajes.Message
{
    public static class MessageCode
    {
        /// <summary>
        /// En este momento no podemos procesar su solicitud. Por favor inténtalo mas tarde.
        ///"Validation": "Falla al tratar de procesar informacion (bd, middleware)"
        /// </summary>
        public static int Message_1 { get { return -1; } }

        /// <summary>
        /// En este momento no podemos validar la información. Por favor inténtalo más tarde.
        ///"Validation":  "Falla de conexion con registraduría"
        /// </summary>
        public static int Message_2 { get { return -2; } }

        /// <summary>
        /// En este momento no podemos enviar mensajes SMS. Por favor inténtalo más tarde.
        ///"Validation":  "Problemas al envíar SMS"
        /// </summary>
        public static int Message_3 { get { return -3; } }

        /// <summary>
        /// EL MENSAJE QUE SE MUESTRA VIENE DEL MIDDLEWARE.
        ///"Validation":  "Problemas en las coordinaciones por reglas de negocio del middleware"
        /// </summary>
        public static int Message_4 { get { return -4; } }

        /// <summary>
        /// Error al cargar la configuración del sistema.
        ///"Validation":  "Problemas al cargar la configuración del sistema."
        /// </summary>
        public static int Message_5 { get { return -5; } }

        /// <summary>
        /// Problemas de conectividad con la pasarela de pagos.
        ///"Validation":  "Problemas de conectividad con la pasarela de pagos UY. Codigos HTTP"
        /// </summary>
        public static int Message_6 { get { return -6; } }

        /// <summary>
        /// Tu compra no pudo ser completada. Comunícate con atención al cliente.
        ///"Validation":  "Problemas durante el pago Códigos de error del negocio de la pasarela."
        /// </summary>
        public static int Message_7 { get { return -7; } }

        /// <summary>
        /// UCM confirma tu coordinación de {0} el {1} en {2}. En caso de que tu coordinación requiera alguna preparación previa. Si no puedes asistir debes cancelar 24 horas antes al tel 24873333.
        ///"Validation":  "mensaje Push al confirmar una coordinación.."
        /// </summary>
        public static int Message1000 { get { return 1000; } }

        /// <summary>
        /// emi te invita a evaluar la atención recibida en la cita de {0} que tuviste el {1}  con {2}
        ///"Validation":  "mensaje Push para evaluar una cita con espcecialista."
        /// </summary>
        public static int Message1001 { get { return 1001; } }

        /// <summary>
        /// El proceso ha sido exitoso
        ///"Validation": "Proceso exitoso"
        /// </summary>
        public static int Message0000 { get { return 0; } }

        /// <summary>
        /// El tipo de documento y el número de documento no pueden estar vacios.
        ///"Validation": "Campos obligatorio del pre-registro"
        /// </summary>
        public static int Message0001 { get { return 1; } }

        /// <summary>
        /// El número de documento que suministraste no es  válido, debes verificarlo.
        ///"Validation": "Valdiación contra el middlware para validar documento"
        /// </summary>
        public static int Message0002 { get { return 2; } }

        /// <summary>
        /// Debe aceptar los terminos de uso y políticas de tratamiento de datos personales.
        ///"Validation": "Campos obligatorio del pre-registro"
        /// </summary>
        public static int Message0003 { get { return 3; } }

        /// <summary>
        /// Debe seleccionar una imagen con un formato valido, jpeg, jpg, png, git.
        ///"Validation": "Validación de clave correcta del usuario"
        /// </summary>
        public static int Message0004 { get { return 4; } }

        /// <summary>
        /// La confirmación del correo no es válida.
        ///"Validation": "Campos obligatorio del pre-registro"
        /// </summary>
        public static int Message0005 { get { return 5; } }
        
    }
}
