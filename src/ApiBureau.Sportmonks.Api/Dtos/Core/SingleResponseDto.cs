using SportMonks.Dtos.Core;

namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class SingleResponseDto<T> : BaseResponseDto
{
    public T Data { get; set; }

    public SingleResultDto<T?> Result => new(Error, Data);

    public SingleResponseDto()
    {

    }

    public SingleResponseDto(ErrorResponseDto error) => Error = error;
}