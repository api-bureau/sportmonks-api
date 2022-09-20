using System.Text.Json.Serialization;

namespace SportMonks.Dtos;

public class SeasonDto : EntityIdDto<int>
{
    public string Name { get; set; } = "";

    [JsonPropertyName(Constants.LeagueId)]
    public int LeagueId { get; set; }

    [JsonPropertyName("is_current_season")]
    public bool IsCurrentSeason { get; set; }

    [JsonPropertyName(Constants.CurrentRoundId)]
    public int? CurrentRoundId { get; set; }

    [JsonPropertyName(Constants.CurrentStageId)]
    public int? CurrentStageId { get; set; }
}
