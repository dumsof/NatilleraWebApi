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
            //se utiliza para que los mensajes presenten la ñ y la tilde de forma correcta.
            Encoding isoLatin1 = Encoding.GetEncoding(28591);
            JObject jsonConfig = JObject.Parse(File.ReadAllText($"{path}{jsonFileName}", isoLatin1));
            return jsonConfig.ToString(Formatting.None);
        }
    }
}
