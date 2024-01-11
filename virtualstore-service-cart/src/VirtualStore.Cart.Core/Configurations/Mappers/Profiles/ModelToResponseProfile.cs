using AutoMapper;
using VirtualStore.Cart.Core.Models;
using VirtualStore.Cart.Domain.Responses;

namespace VirtualStore.Cart.Core.Configurations.Mappers.Profiles;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<CartModel, CartResponse>().ReverseMap();

        CreateMap<CartItemModel, CartItemResponse>()
            .ForMember(dst => dst.TotalAmount, opt => opt
                .MapFrom(dst => dst.Product.Price * dst.Quantity)).ReverseMap();

        CreateMap<CartHeaderModel, CartHeaderResponse>()
            .ForMember(dst => dst.CouponCode, opt => opt
                .MapFrom(src => src.Coupon.CouponCode))
            .ForMember(dst => dst.Username, opt => opt
                .MapFrom(src => src.User.Username)).ReverseMap();

        CreateMap<ProductModel, ProductResponse>()
            .ForMember(dst => dst.CategoryName, opt => opt
                .MapFrom(src => src.Category.Name)).ReverseMap();
    }
}