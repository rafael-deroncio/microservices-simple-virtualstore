namespace VirtualStore.Cart.Domain.Responses;

public class ProductResponse
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
}