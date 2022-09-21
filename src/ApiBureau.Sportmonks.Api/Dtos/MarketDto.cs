namespace ApiBureau.Sportmonks.Api.Dtos;

public class MarketDto : EntityIdDto<int>
{
    public string Name { get; set; } = default!;
}
