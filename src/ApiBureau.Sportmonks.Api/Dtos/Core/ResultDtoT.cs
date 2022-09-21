namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class ResultDto<T> : BaseResultDto
{
    public List<T> Data { get; set; }

    public ResultDto(ErrorResponseDto? error, List<T>? data)
    {
        Error = error;
        Data = data ?? new List<T>();
    }
}
