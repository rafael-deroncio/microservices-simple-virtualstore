namespace VirtualStore.Web.Core.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BrandName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool Active { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
}