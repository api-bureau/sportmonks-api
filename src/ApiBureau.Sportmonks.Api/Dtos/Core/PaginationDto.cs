using System.Text.Json.Serialization;

namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class PaginationDto
{
    public int Total { get; set; }
    public int Count { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    // Maybe this is not needed
    // This was disabled because it is not needed and it returns empty array instead of an object
    //public LinksDto? Links { get; set; }
}