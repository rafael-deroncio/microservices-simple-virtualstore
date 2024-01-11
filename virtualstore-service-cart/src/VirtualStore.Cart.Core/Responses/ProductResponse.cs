﻿namespace VirtualStore.Cart.Core.Responses;

public class ProductResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public CategoryResponse Category { get; set; }
}