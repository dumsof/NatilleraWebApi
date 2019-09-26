namespace Notificacion.Cross.Message
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
        /// El formato del correo no es válido.
        ///"Validation": "Campos obligatorio del pre-registro"
        /// </summary>
        public static int Message0004 { get { return 4; } }

        /// <summary>
        /// La confirmación del correo no es válida.
        ///"Validation": "Campos obligatorio del pre-registro"
        /// </summary>
        public static int Message0005 { get { return 5; } }

        /// <summary>
        /// Verifica que hayas digitado correctamente el número de documento de identidad.
        ///"Validation": "Validacion en el fosyga/registraduria y no hay informacion"
        /// </summary>
        public static int Message0006 { get { return 6; } }

        /// <summary>
        /// Hemos enviado al correo electrónico {0} la información para que puedas finalizar tú registro.
        ///"Validation": "Al terminar el registro de forma exitosa o cuando ya existe y no está activado"
        /// </summary>
        public static int Message0007 { get { return 7; } }

        /// <summary>
        /// El correo electrónico {0} quedo registrado satisfactoriamente. Enviaremos a él un mensaje para que finalices tu registro.
        ///"Validation": "Cuando se registra el correo con la validacion del codigo enviado SMS"
        /// </summary>
        public static int Message0008 { get { return 8; } }

        /// <summary>
        /// El código no es válido, comunícate con nuestra línea de Servicio al Cliente.
        ///"Validation": "Cuando el codigo SMS no es válido o ya expiró"
        /// </summary>
        public static int Message0009 { get { return 9; } }

        /// <summary>
        /// Para finalizar el registro, comunícate con nuestra línea de Servicio al Cliente.
        ///"Validation": "Cuando el celular no coincide con el registrado en el PLS "
        /// </summary>
        public static int Message0010 { get { return 10; } }

        /// <summary>
        /// Ya estás registrado en el portal, si no recuerdas tu contraseña haz clic en recordar contraseña.
        ///"Validation": "Usuario ya registrado y activado"
        /// </summary>
        public static int Message0011 { get { return 11; } }

        /// <summary>
        /// Ya activaste tu usuario. Si olvidaste tu contraseña selecciona la opción Recordar contraseña.
        ///"Validation": "Cuando el usuario trata de activarse por segunda vez"
        /// </summary>
        public static int Message0012 { get { return 12; } }

        /// <summary>
        /// Código de activación {0}
        ///"Validation": "Mensaje para enviar el SMS, no aplica para el front-end"
        /// </summary>
        public static int Message0013 { get { return 13; } }

        /// <summary>
        /// El correo electrónico no coincide con el del afiliado.
        ///"Validation": "Usuario es afiliado pero el email no coincide con el del PLS"
        /// </summary>
        public static int Message0014 { get { return 14; } }

        /// <summary>
        /// El usuario no se encuentra Afiliado.
        ///"Validation": "aplica cuando un usuario no está afiliado"
        /// </summary>
        public static int Message0015 { get { return 15; } }

        /// <summary>
        /// El usuario no se encuentra registrado.
        ///"Validation": "aplica cuando un usuario se loguea y no existe"
        /// </summary>
        public static int Message0016 { get { return 16; } }

        /// <summary>
        /// El usuario o contraseña son inváidos.
        ///"Validation": "aplica cuando un usuario se loguea y no es valido el usuario o contraseña"
        /// </summary>
        public static int Message0017 { get { return 17; } }

        /// <summary>
        /// El usuario se encuentra inactivo.
        ///"Validation": "aplica cuando un usuario se loguea y ya existe pero esta inactivo"
        /// </summary>
        public static int Message0018 { get { return 18; } }

        /// <summary>
        /// Por favor verifica que todos los campos obligatorios han sido diligenciados.
        ///"Validation": "Mensaje genérico, aplica cuando se llama un servicio y los campos obligatorios no estan completos"
        /// </summary>
        public static int Message0019 { get { return 19; } }

        /// <summary>
        /// La contraseña no es válida.
        ///"Validation": "Mensaje genérico, aplica cuando la contraseña no cumple con la politica de contraseña"
        /// </summary>
        public static int Message0020 { get { return 20; } }

        /// <summary>
        /// Hemos enviado al correo electrónico {0} la información para que puedas cambiar la contraseña.
        ///"Validation": "Al enviar correo de olvidar contraseña"
        /// </summary>
        public static int Message0021 { get { return 21; } }

        /// <summary>
        /// No se pudo ejecutar la actualización de los datos personales
        ///"Validation": "Al actualizar datos de la persona en PLS"
        /// </summary>
        public static int Message0022 { get { return 22; } }

        /// <summary>
        /// Ya existe una cuenta de usuario asociada con los datos ingresados.
        ///"Validation": "Al registrarse con un correo o un documento que ya existe"
        /// </summary>
        public static int Message0023 { get { return 23; } }

        /// <summary>
        /// La constraseña ha sido cambiada con éxito.
        ///"Validation": "Al cambiar la contraseña"
        /// </summary>
        public static int Message0024 { get { return 24; } }

        /// <summary>
        /// La cuenta ha sido activada con éxito.
        ///"Validation": "Al activar la cuenta"
        /// </summary>
        public static int Message0025 { get { return 25; } }

        /// <summary>
        /// La coordinación ha sido realizada con éxito. En caso de no poder asistir, debes cancelar la consulta con {0} horas hábiles de anticipación, de lo contrario perderás el derecho a ella. ¡Muchas gracias!
        ///"Validation": "Al confirmar una coordinación con éxito"
        /// </summary>
        public static int Message0026 { get { return 26; } }

        /// <summary>
        /// Tu coordinación ha sido cancelada exitosamente.
        ///"Validation": "Al cancelar una coordinación con éxito"
        /// </summary>
        public static int Message0027 { get { return 27; } }

        /// <summary>
        /// En caso de no poder asistir, debes cancelar la consulta con {0} horas hábiles de anticipación, de lo contrario perderás el derecho a ella.
        ///"Validation": "Al notificr una coordinación pendiente"
        /// </summary>
        public static int Message0028 { get { return 28; } }

        /// <summary>
        /// Recuerda tu cita: Nombre del paciente: {0}, Especialidad: {1}, Nombre del centro médico : {2}, Dirección  : {3}, Día  : {4}, Condiciones de cancelación: {5} 
        /// "Validation": "Al notificr una coordinación pendiente"
        /// </summary>
        public static int Message0029 { get { return 29; } }

        /// <summary>
        /// Tu familiar no fué agregado, ya existe un familiar registrado con ese número de documento.
        ///"Validation": Familiar ya existe
        /// </summary>
        public static int Message0030 { get { return 30; } }

        /// <summary>
        /// No se encontró ningun registro para modificar.
        ///"Validation": Familiar no actualizado
        /// </summary>
        public static int Message0031 { get { return 31; } }

        /// <summary>
        /// No se encontró ningun registro para eliminar.
        ///"Validation": Familiar no eliminado
        /// </summary>
        public static int Message0032 { get { return 32; } }

        /// <summary>
        /// Tu familiar no fue encontrado.
        ///"Validation": Al buscar un familiar
        /// </summary>
        public static int Message0033 { get { return 33; } }

        /// <summary>
        /// La información no pudo ser actualizda.
        ///"Validation": Al fallar la actualizacion de datos de un especialista
        /// </summary>
        public static int Message0034 { get { return 34; } }

        /// <summary>
        /// La información no pudo ser actualizda.
        ///"Validation": Al fallar la actualizacion de datos de un especialista
        /// </summary>
        public static int Message0035 { get { return 35; } }

        /// <summary>
        /// Agenda disponible.
        ///"Validation": Valida que al disponiblizar una agenda esta se encuentre disponible
        /// </summary>
        public static int Message0036 { get { return 36; } }

        /// <summary>
        /// No se encontró información de la persona.
        ///"Validation": "Cuando se consulta informaicon de un afiliado"
        /// </summary>
        public static int Message0037 { get { return 37; } }

        /// <summary>
        /// Agregar Agenda.
        ///"Validation": Mensaje para cuando no es posible agregar una agenda 
        /// </summary>
        public static int Message0038 { get { return 38; } }

        /// <summary>
        /// Hemos enviado al correo electrónico del administrador de especialistas la información para finalizar tú registro.
        ///"Validation": "Cuando se registra un especialista y se le envia un correo"
        /// </summary>
        public static int Message0039 { get { return 39; } }

        /// <summary>
        /// Señor usuario, actualmente usted se encuentra inhabilitado;}} por tanto, no es posible generar su afiliación. Si desea puede comunicarse con un asesor de servicio quien puede explicarle con mayor detalle la situación.
        ///"Validation": "Cuando una persona ha tenido reporte de mal uso."
        /// </summary>
        public static int Message0040 { get { return 40; } }

        /// <summary>
        /// Señor usuario, actualmente la persona con tipo documento {0} y número {1} ya cuenta con una afiliación activa, por favor seleccione otra persona.
        ///"Validation": "Cuando una persona ya tiene una afiliacion activa."
        /// </summary>
        public static int Message0041 { get { return 41; } }

        /// <summary>
        /// Señor usuario, no tenemos información disponible sobre su afiliación al régimen contributivo;}} por tanto, no es posible generar su afiliación. Si desea puede comunicarse con un asesor de servicio quien puede explicarle con mayor detalle la situación.
        ///"Validation": "Validación al régimen contributivo."
        /// </summary>
        public static int Message0042 { get { return 42; } }

        /// <summary>
        /// Señor usuario, actualmente usted NO se encuentra afiliado al régimen contributivo;}} por tanto, no es posible generar su afiliación. Si desea puede comunicarse con un asesor de servicio quien puede explicarle con mayor detalle la situación.
        ///"Validation": "Validación al régimen contributivo."
        /// </summary>
        public static int Message0043 { get { return 43; } }

        /// <summary>
        /// Señor usuario, actualmente usted se encuentra afiliado al régimen contributivo pero INACTIVO;}} por tanto, no es posible generar su afiliación. Si desea puede comunicarse con un asesor de servicio quien puede explicarle con mayor detalle la situación.
        ///"Validation": "Validación al régimen contributivo."
        /// </summary>
        public static int Message0044 { get { return 44; } }

        /// <summary>
        /// Actualizar cita .
        ///"Validation": Mensaje para cuando no es posible actualizar una cita.
        /// </summary>
        public static int Message0045 { get { return 45; } }

        /// <summary>
        /// El especialista se encuentra inactivo.
        ///"Validation": El especialista se encuentra inactivo..
        /// </summary>
        public static int Message0046 { get { return 46; } }

        /// <summary>
        /// Error al cambiar la contraseña.
        ///"Validation": "Error al cambiar la contraseña"
        /// </summary>
        public static int Message0047 { get { return 47; } }

        /// <summary>
        /// Error al registrar la información. Es posible que el correo electrónico ya esté registrado o que los campos obligatorios no han sido diligenciados.
        ///"Validation": "Error al registrar un usuario"
        /// </summary>
        public static int Message0048 { get { return 48; } }

        /// <summary>
        /// El tipo de documento no es válido, si deseas puedes comunicarte con un asesor comercial quien puede explicarte con mayor detalle la situación.
        ///"Validation": "Error al seleccionar un tipo de documento no válido"
        /// </summary>
        public static int Message0049 { get { return 49; } }

        /// <summary>
        /// Ya existe un tipo y número documento registrado con los datos ingresados.
        ///"Validation": "Al registrarse con un tipo y documento, pais y rol que ya existe"
        /// </summary>
        public static int Message0050 { get { return 50; } }

        /// <summary>
        /// El correo {0} quedo registrado satisfactoriamente, enviaremos a tu mail un mensaje para finalizar el registro.
        ///"Validation": "Al terminar el registro de forma exitosa o cuando se actualiza el correo en el PLS"
        /// </summary>
        public static int Message0051 { get { return 51; } }

        /// <summary>
        /// El registro del especialista ha sido descartado, la información a sido removida.
        ///"Validation": "Al momento de no aceptar el registro de un especialista"
        /// </summary>
        public static int Message0052 { get { return 52; } }

        /// <summary>
        /// El proceso de registro ha sido cancelado.
        ///"Validation": "Al momento del usuario cancelar el registro"
        /// </summary>
        public static int Message0053 { get { return 53; } }

        /// <summary>
        /// Hemos enviado al correo electrónico {0} el registro clínico seleccionado.
        /// "Validation": "Al fallar el pago en una confirmación de coordinación"
        /// </summary>
        public static int Message0054 { get { return 54; } }

        /// <summary>
        /// Registro clínico no disponible para enviar por correo electrónico. Debes comunicarte con nuestra línea de Servicio al Cliente.
        ///"Validation": "Al enviar el registro clínico y éste no existe"
        /// </summary>
        public static int Message0055 { get { return 55; } }


        /// <summary>
        /// Cancelacion de servicio.
        /// </summary>
        public static int Message0056 { get { return 56; } }


        /// <summary>
        /// ¡Gracias por calificarnos!.
        /// </summary>
        public static int Message0057 { get { return 57; } }

        /// <summary>
        /// ¡Gracias! Ya recibimos tu evaluación.
        /// </summary>
        public static int Message0058 { get { return 58; } }

        /// <summary>
        /// No se pueden registrar menores de edad.
        ///"Validation": "Al intentar registrar un menor de edad."
        /// </summary>
        public static int Message0061 { get { return 61; } }
    }
}
