namespace ApiBureau.Sportmonks.Api.Dtos;

public class BookmakerDto : EntityIdDto<int>
{
    public string Name { get; set; } = null!;
    public string? Logo { get; set; }
}