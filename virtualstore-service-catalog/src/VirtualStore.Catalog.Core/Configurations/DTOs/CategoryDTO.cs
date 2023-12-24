namespace VirtualStore.Catalog.Core.Configurations.DTOs;

/// <summary>
/// Represents a category entity.
/// </summary>
public class CategoryDTO : EntityConventionsDTO
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}