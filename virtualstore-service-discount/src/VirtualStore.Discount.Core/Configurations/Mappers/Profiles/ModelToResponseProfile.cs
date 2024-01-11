using AutoMapper;
using VirtualStore.Discount.Core.Models;
using VirtualStore.Discount.Core.Responses;
using VirtualStore.Discount.Domain.Responses;

namespace VirtualStore.Discount.Core.Configurations.Mappers.Profiles;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<CategoryModel, CategoryResponse>().ReverseMap();
        CreateMap<CouponModel, CouponResponse>().ReverseMap();
        CreateMap<CouponModel, CouponDetailsResponse>()
            
            .ForMember(src => src.TotalUses, opt => opt
                .MapFrom(dst => dst.Usagehistory.Users.Count()))

            .ForMember(src => src.Categires, opt => opt
                .MapFrom(dst => dst.Categories.Select(category => category.Name))).ReverseMap();
    }
}