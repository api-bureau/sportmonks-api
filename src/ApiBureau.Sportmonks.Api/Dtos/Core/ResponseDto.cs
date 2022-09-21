namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class ResponseDto<T> : BaseResponseDto
{
    public List<T> Data { get; set; } = new List<T>();

    public ResultDto<T> Result => new(Error, Data);

    public ResponseDto() { }

    public ResponseDto(ErrorResponseDto error) => Error = error;
}