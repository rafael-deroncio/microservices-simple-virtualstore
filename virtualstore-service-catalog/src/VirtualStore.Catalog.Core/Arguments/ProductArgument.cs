using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Catalog.Core.Arguments;

public class ProductArgument : ProductDTO
{
    public int CategoryId { get; set; }
}