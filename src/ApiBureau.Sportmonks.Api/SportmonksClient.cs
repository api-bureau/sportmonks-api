namespace ApiBureau.Sportmonks.Api;

public class SportMonksClient
{
    private readonly ClientHelper _client;
    public FixtureEndpoint Fixtures { get; }
    public GenericEndpoint<CountryDto> Countries { get; }
    public GenericEndpoint<LeagueDto> Leagues { get; }
    public GenericEndpoint<SeasonDto> Seasons { get; }
    public GenericEndpoint<MarketDto> Markets { get; }
    public GenericEndpoint<BookmakerDto> Bookmaker { get; }
    public TeamEndpoint Teams { get; }
    public VenueEndpoint Venues { get; }

    public SportMonksClient(ClientHelper client)
    {
        _client = client;
        Bookmaker = new GenericEndpoint<BookmakerDto>(client, EndPointType.Bookmaker);
        Countries = new GenericEndpoint<CountryDto>(client, EndPointType.Country);
        Fixtures = new FixtureEndpoint(client);
        Leagues = new GenericEndpoint<LeagueDto>(client, EndPointType.League);
        Markets = new GenericEndpoint<MarketDto>(client, EndPointType.Market);
        Seasons = new GenericEndpoint<SeasonDto>(client, EndPointType.Seasons);
        Teams = new TeamEndpoint(client);
        Venues = new VenueEndpoint(client);
    }

    public Task<HttpResponseMessage> GetRawAsync(string logoPath) => _client.GetRawAsync(logoPath);
}
