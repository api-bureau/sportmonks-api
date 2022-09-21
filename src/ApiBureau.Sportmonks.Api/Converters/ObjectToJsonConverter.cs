namespace ApiBureau.Sportmonks.Api.Converters;

public class ObjectToJsonConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);

        return document.RootElement.Clone().GetRawText();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => throw new NotImplementedException();
}