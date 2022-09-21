using ApiBureau.Sportmonks.Api.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiBureau.Sportmonks.Api.Http;

public class ClientHelper
{
    private readonly ILogger<ClientHelper> _logger;
    private readonly HttpClient _client;
    private readonly SportmonksSettings _settings;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        IgnoreNullValues = true,
        PropertyNameCaseInsensitive = true
    };
    private Dictionary<string, string> _queryString = new();

    public ClientHelper(ILogger<ClientHelper> logger, HttpClient client, IOptions<SportmonksSettings> settings)
    {
        _logger = logger;
        _client = client;
        _settings = settings.Value;

        CheckInitialisation();
    }

    public async Task<SingleResultDto<T?>> EntityAsync<T>(string query)
    {
        var response = await ApiGetAsync(query);

        // Deserialization might give us some error clues
        var dto = await DeserializeAsync<SingleResponseDto<T>>(response);

        if (!response.IsSuccessStatusCode)
            _logger.LogError($"{dto?.Error?.Code ?? 0}:{dto?.Error?.Message ?? "Http Error"}");

        return dto?.Result ?? new SingleResultDto<T?>(new ErrorResponseDto() { Message = "No Data" });
    }

    public async Task<ResultDto<T>> GetAsync<T>(string query, int? perPage = null)
    {
        var response = await ApiGetAsync<T>(query, 1, perPage ?? _settings.PerPage);

        if (response.IsFailure || response.Meta == null)
        {
            _logger.LogError($"{response?.Error?.Code}:{response?.Error?.Message}");

            return response!.Result;
        }

        if (response.Meta.Pagination.TotalPages == 1) return response.Result;

        var data = response.Data;

        for (var i = 2; i <= response.Meta.Pagination.TotalPages; i++)
        {
            response = await ApiGetAsync<T>(query, i, response.Meta.Pagination.PerPage);

            if (response.IsFailure || response.Meta == null)
            {
                _logger.LogError($"{response.Error?.Code}:{response.Error?.Message}");

                return response.Result;
            }

            data.AddRange(response.Data);
        }

        response.Data = data;

        _logger.LogInformation($"Total items: {response.Result.Data.Count}");

        return response.Result;
    }

    public async Task<ResponseDto<T>> ApiGetAsync<T>(string query, int page = 1, int perPage = 0)
    {
        if (perPage > 0)
            query = $"{query}{AddSeparator(query)}per_page={perPage}&page={page}";

        if (_settings.IncludeDeletedFixtures && query.StartsWith("fixtures"))
            query = $"{query}{AddSeparator(query)}deleted=1";

        var response = await ApiGetAsync(query);

        if (!response.IsSuccessStatusCode)
            return new ResponseDto<T>(
                new ErrorResponseDto(response.ReasonPhrase == "Too Many Requests" ? 429 : 0, response.ReasonPhrase ?? ""));

        var responseDto = await DeserializeAsync<ResponseDto<T>>(response);

        _logger.LogInformation("Page: {0}/{1}, Size: {2}MB", page, responseDto?.Meta?.Pagination?.TotalPages ?? 1, response.Content.Headers.ContentLength?.ToPrettySize(NumberExtension.SizeUnits.MB) ?? "");

        return responseDto ?? new ResponseDto<T>();
    }

    public async Task<HttpResponseMessage> ApiGetAsync(string query)
    {
        return await _client.GetAsync(GetUrl());

        string GetUrl() => QueryHelpers.AddQueryString($"{_settings.BaseAddress}/{query}", _queryString);
    }

    public async Task<HttpResponseMessage> GetRawAsync(string query) => await _client.GetAsync(query);

    public async Task<T?> DeserializeAsync<T>(HttpResponseMessage response)
    {
        await using var stream = await response.Content.ReadAsStreamAsync();

        try
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, _jsonSerializerOptions);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Deserialize Error at {uri}", response.RequestMessage?.RequestUri);
            throw;
        }
    }

    //private static string GetSize(HttpResponseHeaders? headers)
    //{
    //    if (headers == null) return "unknown";

    //    headers.TryGetValues("Content-Length", out var values);

    //    var contentLength = values.FirstOrDefault();

    //    if (contentLength == null) return "unknown";

    //    long.TryParse(contentLength, out var length);

    //    return length.ToPrettySize(NumberExtension.SizeUnits.MB);
    //}

    private void CheckInitialisation()
    {
        if (string.IsNullOrWhiteSpace(_settings.ApiToken) || string.IsNullOrWhiteSpace(_settings.BaseAddress))
            _logger.LogError(
                "SportMonksSettings needs to be added and initialised Configuration.GetSection(nameof(SportMonksSettings).");
        else
            _queryString = new Dictionary<string, string>
            {
                {"api_token", _settings.ApiToken},
                {"tz", _settings.Timezone},
                //{"per_page", _settings.PerPage.ToString()}
            };
    }

    private string AddSeparator(string query) => query.Contains("?") ? "&" : "?";
}
