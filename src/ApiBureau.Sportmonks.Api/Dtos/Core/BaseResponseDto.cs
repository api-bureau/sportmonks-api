namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class BaseResponseDto
{
    public MetaDto? Meta { get; set; }

    public ErrorResponseDto? Error { get; set; }

    public bool IsFailure => Error != null;

    public BaseResponseDto()
    {

    }

    public BaseResponseDto(ErrorResponseDto error) => Error = error;
}