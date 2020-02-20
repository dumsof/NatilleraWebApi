namespace Natillera.CrossClothing.Mensajes.Message
{
    using Natillera.CrossClothing.Mensajes.json;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Message
    {
        public int Code { get; set; }
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public string Title { get; set; }

        public Mensaje Mensaje { get; set; }

        private readonly MessageInfo messageInfo;
        public Message(int code)
        {
            this.messageInfo = GetMessageInfo(code);
            this.DiligenciarMensaje(this.messageInfo);
        }

        public Message(string code)
        {
            this.messageInfo = GetMessageInfo(code);
            this.DiligenciarMensaje(this.messageInfo);
        }

        public Message(int code, string messageValue)
        {
            this.messageInfo = GetMessageInfo(code);
            Text = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Text, messageValue);
            this.DiligenciarMensaje(this.messageInfo);
        }

        public Message(string code, string messageValue)
        {
            this.messageInfo = GetMessageInfo(code);
            Text = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Text, messageValue);
            this.DiligenciarMensaje(this.messageInfo);
        }

        public Message(int code, string messageValue, string title)
        {
            this.messageInfo = GetMessageInfo(code);
            Text = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Text, messageValue);
            Title = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Title, title);
            this.DiligenciarMensaje(this.messageInfo);
        }

        public Message(int code, int newCode, string messageValue, string title) : this(code, messageValue, title)
        {
            Code = newCode;
        }

        public Message(int code, int newCode, string title) : this(code, newCode)
        {
            Title = title;
            Code = newCode;
        }

        public Message(int code, string[] messagesValue)
        {
            this.messageInfo = GetMessageInfo(code);
            this.DiligenciarMensaje(this.messageInfo);
            Text = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Text, messagesValue);
        }

        public Message(int code, string[] messageValue, string title)
        {
            this.messageInfo = GetMessageInfo(code);
            this.DiligenciarMensaje(this.messageInfo);
            Text = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Text, messageValue);
            Title = string.Format(CultureInfo.CurrentCulture, this.messageInfo.Title, title);
        }

        public Message(int code, int newCode)
        {
            this.messageInfo = GetMessageInfo(code);
            this.DiligenciarMensaje(this.messageInfo);
            Code = newCode;
        }

        public Message(string newMessage, int code)
        {
            this.messageInfo = GetMessageInfo(code);
            this.DiligenciarMensaje(this.messageInfo);
            Text = newMessage;
        }

        private MessageInfo GetMessageInfo(int code)
        {
            MessageInfo messageInfo = GetMessage(code);
            Code = Convert.ToInt32(messageInfo.Code);
            Text = messageInfo.Text;
            Type = messageInfo.Type;
            Title = messageInfo.Title;
            return messageInfo;
        }

        private MessageInfo GetMessageInfo(string code)
        {
            MessageInfo messageInfo = GetMessage(code);
            Code = 0;
            Text = messageInfo.Text;
            Type = messageInfo.Type;
            Title = messageInfo.Title;
            return messageInfo;
        }

        private MessageInfo GetMessage(int code)
        {
            MessagesList rootObject = JsonFile.FromJson<MessagesList>("\\Mensajes\\MensajesJSon\\MensajeNegocio.json");
            MessageInfo message = rootObject.MessageInfo.FirstOrDefault(s => Convert.ToInt32(s.Code) == code);

            if (message == null)
            {
                message = new MessageInfo();
            }

            return message;
        }

        private MessageInfo GetMessage(string code)
        {
            MessagesList rootObject = JsonFile.FromJson<MessagesList>("\\Mensajes\\MensajesJSon\\MensajeNegocio.json");
            MessageInfo message = rootObject.MessageInfo.FirstOrDefault(s => s.Code == code);
            if (message == null)
            {
                message = new MessageInfo();
            }

            return message;
        }

        private void DiligenciarMensaje(MessageInfo messageInfo)
        {
            this.Mensaje = new Mensaje
            {
                Contenido = string.Format(CultureInfo.CurrentCulture, messageInfo.Text),
                Identificador = Convert.ToInt32(messageInfo.Code),
                Titulo = string.Format(CultureInfo.CurrentCulture, messageInfo.Title),
                TipoMensaje = messageInfo.Type
            };
        }

    }
}
