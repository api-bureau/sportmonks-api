using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SportMonks.Converters
{
    public class NumberAndStringToNumberConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return null;

            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetInt32(out var value)) return value;

                if (reader.TryGetDouble(out var doubleValue)) return (int)doubleValue;
            }

            if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out var number))
                return number;

            return 0;
        }

        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options) => throw new NotImplementedException();
    }
}