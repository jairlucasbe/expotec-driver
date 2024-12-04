using Newtonsoft.Json;

namespace expotec_driver.Helpers
{
    public class JsonParser
    {
        public static string ToJson(object obj)
        {
            if (obj == null)
                return "null";
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static string ToJsonCompact(object obj)
        {
            if (obj == null)
                return "null";
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
                return Activator.CreateInstance<T>();
            return JsonConvert.DeserializeObject<T>(json) ?? Activator.CreateInstance<T>();
        }
    }
}
