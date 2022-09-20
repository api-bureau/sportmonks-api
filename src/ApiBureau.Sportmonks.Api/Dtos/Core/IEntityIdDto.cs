namespace ApiBureau.Sportmonks.Api.Dtos.Core;

public interface IEntityIdDto<out TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; }
}