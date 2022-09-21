namespace ApiBureau.Sportmonks.Api.Converters;

public class DoubleAndStringToDoubleConverter : JsonConverter<double?>
{
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;

        if (reader.TokenType == JsonTokenType.Number)
            //if (reader.TryGetInt32(out var value)) return value;

            if (reader.TryGetDouble(out var doubleValue))
                return doubleValue;

        if (reader.TokenType == JsonTokenType.String && double.TryParse(reader.GetString(), out var number))
            return number;

        return 0;
    }

    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options) => throw new NotImplementedException();
}