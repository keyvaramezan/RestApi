using RestApi.Domain.Data.Core;

namespace RestApi.Domain;
public class Product : Entity<int>
{
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public override string ToString() => $"id: {Id}, name: {Name}";
    public Product() => Images = new List<Image>();

    public List<Image> Images { get; set; }
}