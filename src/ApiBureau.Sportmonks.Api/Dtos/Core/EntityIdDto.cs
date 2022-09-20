namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public class EntityIdDto<TKey> : IEntityIdDto<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
}
