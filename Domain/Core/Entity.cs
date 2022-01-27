namespace RestApi.Domain.Data.Core
{
    public abstract class Entity<key> : IEntity<key>
    {
        public key? Id { get; set; }
    }
}
