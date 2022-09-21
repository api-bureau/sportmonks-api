namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class SingleResultDto<T> : BaseResultDto
{
    public T? Data { get; set; }

    public SingleResultDto(ErrorResponseDto? error, T data)
    {
        Error = error;
        Data = data;
    }

    public SingleResultDto(ErrorResponseDto? error) => Error = error;
}
