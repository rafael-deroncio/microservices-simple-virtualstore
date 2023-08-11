﻿namespace VirtualStore.Catalog.Domain.Responses;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
}