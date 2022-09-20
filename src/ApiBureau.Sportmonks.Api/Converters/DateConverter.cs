using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SportMonks.Converters
{
    // This doesn't support nulls
    public class DateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTime.Parse(reader.GetString());

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => throw new NotImplementedException();
    }
}