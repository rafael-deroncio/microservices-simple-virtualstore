using VirtualStore.Catalog.Core.Configurations.Mappers;
using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services;

public class ProductService : IProductService
{
    private readonly IObjectConverter _objectConverter;

    public ProductService(IObjectConverter objectConverter)
    {
        _objectConverter = objectConverter;
    }

    public async Task<ProductResponse> CreateProduct(ProductRequest product)
    {
        await Task.Delay(100);
        return new ProductResponse
        {
            Id = 1,
            Name = "Product 1",
            Description = "Description for Product 1",
            Brand = "Brand A",
            Price = 99.99m,
            Stock = 10,
            Active = true,
            CategoryName = "Category X",
            CategoryId = 101
        };
    }

    public async Task<bool> DeleteProduct(int id)
    {
        await Task.Delay(100);
        return true;
    }

    public async Task<ProductResponse> GetProduct(int id)
    {
        await Task.Delay(100);
        return new ProductResponse
        {
            Id = 1,
            Name = "Product 1",
            Description = "Description for Product 1",
            Brand = "Brand A",
            Price = 99.99m,
            Stock = 10,
            Active = true,
            CategoryName = "Category X",
            CategoryId = 101
        };
    }

    public async Task<IEnumerable<ProductResponse>> GetProducts()
    {
        await Task.Delay(100);
        return new List<ProductResponse>
        {
            new ProductResponse
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description for Product 1",
                Brand = "Brand A",
                Price = 99.99m,
                Stock = 10,
                Active = true,
                CategoryName = "Category X",
                CategoryId = 101
            },
            new ProductResponse
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description for Product 2",
                Brand = "Brand B",
                Price = 199.99m,
                Stock = 5,
                Active = true,
                CategoryName = "Category Y",
                CategoryId = 102
            }
        };
    }

    public async Task<ProductResponse> UpdateProduct(int id, ProductRequest product)
    {
        await Task.Delay(100);
        return new ProductResponse
        {
            Id = 1,
            Name = "Product 1",
            Description = "Description for Product 1",
            Brand = "Brand A",
            Price = 99.99m,
            Stock = 10,
            Active = true,
            CategoryName = "Category X",
            CategoryId = 101
        };
    }
}
