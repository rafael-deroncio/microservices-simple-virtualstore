using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Catalog.Core.Model;

public class ProductModel : ProductDTO
{
    public CategoryModel Category { get; set; }
}