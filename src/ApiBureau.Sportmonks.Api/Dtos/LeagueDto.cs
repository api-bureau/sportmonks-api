using System.Text.Json.Serialization;

namespace SportMonks.Dtos;

public class LeagueDto : EntityIdDto<int>
{
    public string Name { get; set; } = "";

    [JsonPropertyName(Constants.CountryId)]
    public int CountryId { get; set; }

    public bool Active { get; set; }

    [JsonPropertyName("live_standings")]
    public bool LiveStandings { get; set; }

    [JsonPropertyName("is_cup")]
    public bool IsCup { get; set; }

    public string Type { get; set; } = "";

    [JsonPropertyName(Constants.LogoPath)]
    public string LogoPath { get; set; } = "";

    [JsonPropertyName(Constants.CurrentSeasonId)]
    public int? SeasonId { get; set; }

    [JsonPropertyName(Constants.CurrentRoundId)]
    public int? RoundId { get; set; }

    [JsonPropertyName(Constants.CurrentStageId)]
    public int? StageId { get; set; }

    public CoverageDto Coverage { get; set; } = default!;
}
