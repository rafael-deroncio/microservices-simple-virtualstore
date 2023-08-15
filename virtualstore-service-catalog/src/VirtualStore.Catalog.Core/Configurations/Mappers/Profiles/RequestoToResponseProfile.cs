using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;
using AutoMapper;

namespace VirtualStore.Catalog.Core.Configurations.Mappers.Profiles;

public class RequestoToResponseProfile : Profile
{
    public RequestoToResponseProfile()
    {
        CreateMap<ProductRequest, ProductResponse>().ReverseMap();
        CreateMap<CategoryRequest, CategoryResponse>().ReverseMap();
    }
}