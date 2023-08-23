﻿namespace VirtualStore.Catalog.Core.Configurations.DTOs;

/// <summary>
/// Represents a product entity.
/// </summary>
public class ProductDTO : EntityConventionsDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}