namespace ApiBureau.Sportmonks.Api.Converters;

public class NumberAndStringToStringConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        //if (reader.TokenType == JsonTokenType.String) return reader.GetString();

        if (reader.TokenType == JsonTokenType.Number) return reader.GetInt64().ToString();

        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => throw new NotImplementedException();
}