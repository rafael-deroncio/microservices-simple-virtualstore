using AutoMapper;
using VirtualStore.Cart.Core.Arguments;

namespace VirtualStore.Cart.Core.Configurations.Mappers.Profiles;

public class ResponseToArgument : Profile
{
    public ResponseToArgument()
    {
        CreateMap<Responses.ProductResponse, ProductArgument>()
            .ForMember(dst => dst.CategoryName, opt => opt
                .MapFrom(src => src.Category.Name)).ReverseMap();
    }
}