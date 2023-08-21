using AutoMapper;
using VirtualStore.Web.Core.ViewModels;
using VirtualStore.Web.Core.Responses;

namespace VirtualStore.Web.Core.Configurations.Mappers.Profiles;

public class ResponseToViewModelProfile : Profile
{
    public ResponseToViewModelProfile()
    {
        CreateMap<ProductResponse, ProductViewModel>().ReverseMap();
        CreateMap<CategoryResponse, CategoryViewModel>().ReverseMap();
    }
}