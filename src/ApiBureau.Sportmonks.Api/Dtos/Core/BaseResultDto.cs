namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class BaseResultDto
{
    public ErrorResponseDto? Error { get; set; }

    public bool IsFailure => Error != null;

    public bool IsSuccess => Error == null;
}
