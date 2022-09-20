namespace ApiBureau.Sportmonks.Api.Core;

public class SportmonksSettings
{
    public string BaseAddress { get; set; } = "";
    public string ApiToken { get; set; } = "";
    public string Timezone { get; set; } = "";
    public int PerPage { get; set; }
    public bool IncludeDeletedFixtures { get; set; }
}
