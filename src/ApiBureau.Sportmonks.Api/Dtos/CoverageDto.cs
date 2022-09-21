namespace ApiBureau.Sportmonks.Api.Dtos;

public class CoverageDto
{
    public bool Predictions { get; set; }

    [JsonPropertyName("topscorer_goals")]
    public bool TopScorerGoals { get; set; }

    [JsonPropertyName("topscorer_assists")]
    public bool TopScorerAssists { get; set; }

    [JsonPropertyName("topscorer_cards")]
    public bool TopScorerCards { get; set; }
}
