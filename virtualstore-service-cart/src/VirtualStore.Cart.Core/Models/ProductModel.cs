﻿using VirtualStore.Cart.Core.Configurations.DTOs;

namespace VirtualStore.Cart.Core.Models;

public class ProductModel
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public CategoryModel Category { get; set; }
}