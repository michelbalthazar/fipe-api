using Newtonsoft.Json;
using System.Text;

namespace System
{
    public static class StringExtension
    {
        public static byte[] GetBytesFromString(this string value) => Encoding.UTF8.GetBytes(value);

        public static T JsonToObject<T>(this string json) where T : class => JsonConvert.DeserializeObject<T>(json);

        public static string ToJson<T>(this object value) => JsonConvert.SerializeObject(value);
    }
}