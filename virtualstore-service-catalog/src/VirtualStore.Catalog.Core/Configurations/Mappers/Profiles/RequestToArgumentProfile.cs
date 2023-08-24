using AutoMapper;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Domain.Requests;

namespace VirtualStore.Catalog.Core.Configurations.Mappers.Profiles;

public class RequestToArgumentProfile : Profile
{
    public RequestToArgumentProfile()
    {
        CreateMap<ProductRequest, ProductArgument>().ReverseMap();
        CreateMap<CategoryRequest, CategoryArgument>().ReverseMap();
        CreateMap<PaginationRequest, PaginationArgument>().ReverseMap();
    }
}