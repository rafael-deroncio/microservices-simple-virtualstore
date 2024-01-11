using AutoMapper;
using VirtualStore.Discount.Core.Models;
using VirtualStore.Discount.Core.Arguments;

namespace VirtualStore.Discount.Core.Configurations.Mappers.Profiles;

public class ModelToArgumentProfile : Profile
{
    public ModelToArgumentProfile()
    {
        CreateMap<CategoryModel, CategoryCouponArgument>()
            .ForMember(src => src.CategoryName, opt => opt
                .MapFrom(dst => dst.Name)).ReverseMap();
        CreateMap<CouponModel, CouponArgument>().ReverseMap();

    }
}