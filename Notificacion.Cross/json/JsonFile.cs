namespace Notificacion.Cross.json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;   
    using System.IO;
  

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
            JObject jsonConfig = JObject.Parse(File.ReadAllText($"{path}{jsonFileName}"));
            return jsonConfig.ToString(Formatting.None);
        }
    }
}
