namespace ApiBureau.Sportmonks.Api.Endpoints;

public class GenericEndpoint<T>
{
    protected readonly ClientHelper Client;
    private readonly string _endpointType;
    protected int PerPage { get; set; } = 2000;

    public GenericEndpoint(ClientHelper client, string endpointType)
    {
        Client = client;
        _endpointType = endpointType;
    }

    /// <summary>
    /// Returns all items
    /// </summary>
    /// <returns></returns>
    public Task<ResultDto<T>> GetAsync() => Client.GetAsync<T>(_endpointType, PerPage);

    //public Task<SingleResultDto<T>> GetAsync(int entityId)
    //    => Client.EntityAsync<T>($"{_endpointType}/{entityId}");

    /// <summary>
    /// Returns requested entity
    /// </summary>
    /// <param name="entityId"></param>
    /// <param name="includes">Comma separated includes</param>
    /// <returns></returns>
    public Task<SingleResultDto<T?>> GetAsync(int entityId, string includes = "")
        => Client.EntityAsync<T>($"{_endpointType}/{entityId}{AddIncludes(includes)}");

    public static GenericEndpoint<T> Create(ClientHelper client, string endpointType)
        => new(client, endpointType);

    public string AddIncludes(string includes) => string.IsNullOrWhiteSpace(includes) ? "" : $"?include={includes.Replace(" ", "")}";
}
