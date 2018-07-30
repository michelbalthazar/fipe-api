using Newtonsoft.Json;
using System.Text;

namespace System
{
    public static class StringExtension
    {
        public static byte[] GetBytesFromString(this string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static T JsonToObject<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToJson<T>(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
