
using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Catalog.Core.Arguments;

public class CategoryProductArgument : EntityConventionsDTO
{
    public int CategoryProductId { get; set; }
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
}
