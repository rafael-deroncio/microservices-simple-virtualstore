namespace VirtualStore.Catalog.Domain.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool Active { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
}