﻿namespace VirtualStore.Web.Core.Models;

public class ProductViewModel
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