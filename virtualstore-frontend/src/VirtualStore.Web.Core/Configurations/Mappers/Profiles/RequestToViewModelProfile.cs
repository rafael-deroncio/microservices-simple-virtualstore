using AutoMapper;
using VirtualStore.Web.Core.Models;
using VirtualStore.Web.Core.Requests;

namespace VirtualStore.Web.Core.Configurations.Mappers.Profiles;

public class RequestToViewModelProfile : Profile
{
    public RequestToViewModelProfile()
    {
        CreateMap<ProductRequest, ProductViewModel>().ReverseMap();
        CreateMap<CategoryRequest, CategoryViewModel>().ReverseMap();
    }
}