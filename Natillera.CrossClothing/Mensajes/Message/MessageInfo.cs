namespace Natillera.CrossClothing.Mensajes.Message
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MessageInfo
    {
        [JsonProperty("Type")]
        public MessageType Type { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("Text")]
        public string Text { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
    }

    public class MessagesList
    {
        [JsonProperty("MessageInfo")]
        public List<MessageInfo> MessageInfo { get; set; }
    }
}
