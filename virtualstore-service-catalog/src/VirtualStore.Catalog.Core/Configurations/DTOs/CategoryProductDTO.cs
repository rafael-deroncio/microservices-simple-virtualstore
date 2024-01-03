namespace VirtualStore.Catalog.Core.Configurations.DTOs;

public class CategoryProductDTO : EntityConventionsDTO
{
    public int CategoryProductId { get; set; }
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
}