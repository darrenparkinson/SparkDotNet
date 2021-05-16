using System;
using Newtonsoft.Json;

namespace SparkDotNet
{
    /// <summary>
    /// This is a utility class to convert a TimeZoneInfo from/to JSon.
    /// The default converter would throw an exception.
    /// </summary>
    public class TimeZoneInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return System.TimeZoneInfo.FindSystemTimeZoneById(s);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((TimeZoneInfo)value).Id);
        }
    }
}
