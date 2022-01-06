namespace RestApi.Domain.Data.Core
{
    public interface IEntity<key>
    {
        key Id { get; set; }
    }
}
