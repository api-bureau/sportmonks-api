namespace SportMonks.Dtos.Core;

public class ErrorResponseDto
{
    public string Message { get; set; } = "";

    public int Code { get; set; }

    public ErrorResponseDto()
    {

    }

    public ErrorResponseDto(int code, string message)
    {
        Code = code;
        Message = message;
    }

    //public bool Success => string.IsNullOrWhiteSpace(Message) && Code == 0;
}