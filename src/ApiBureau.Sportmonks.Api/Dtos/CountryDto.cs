using ApiBureau.Sportmonks.Api.Converters;

namespace ApiBureau.Sportmonks.Api.Dtos;

public class CountryDto : EntityIdDto<int>
{
    public string Name { get; set; } = "";

    [JsonPropertyName(Constants.ImagePath)]
    public string ImagePath { get; set; } = "";

    public ExtraDto? Extra { get; set; } = default!;

    public class ExtraDto
    {
        public string? Continent { get; set; }

        [JsonPropertyName("sub_region")]
        public string? SubRegion { get; set; }

        [JsonPropertyName("world_region")]
        public string? WorldRegion { get; set; }

        // Sometimes this is a number 0
        [JsonConverter(typeof(NumberAndStringToStringConverter))]
        public string? Fifa { get; set; }
        public string? Iso { get; set; }
        public string? Iso2 { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Flag { get; set; }
    }
}
