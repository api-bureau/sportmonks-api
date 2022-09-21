namespace ApiBureau.Sportmonks.Api.Converters;

public class NullToZeroConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return 0;

        return reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options) => throw new NotImplementedException();
}