namespace Natillera.CrossClothing.Mensajes.json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Text;

    public static class JsonFile
    {
        public static T FromJson<T>(string jsonFileName)
        {
            return JsonConvert.DeserializeObject<T>(ReadJsonFromFile(jsonFileName));
        }

        private static string ReadJsonFromFile(string jsonFileName)
        {
            string path = string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath) ?
                AppDomain.CurrentDomain.BaseDirectory : AppDomain.CurrentDomain.RelativeSearchPath;
            //se utiliza Encoding.GetEncoding para que los mensajes presenten la ñ y la tilde de forma correcta.         
            JObject jsonConfig = JObject.Parse(File.ReadAllText($"{path}{jsonFileName}", Encoding.GetEncoding(28591)));
            return jsonConfig.ToString(Formatting.None);
        }
    }
}
