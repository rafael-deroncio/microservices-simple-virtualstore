using AutoMapper;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Models;

namespace VirtualStore.Identity.Core.Configurations.Mappers.Profiles;

public class ArgumentToModelProfile : Profile
{
    public ArgumentToModelProfile()
    {
        CreateMap<UserArgument, UserModel>().ReverseMap();
        CreateMap<AddressArgument, AddressModel>().ReverseMap();
        CreateMap<TelephoneArgument, TelephoneModel>().ReverseMap();
        CreateMap<RoleArgument, RoleModel>().ReverseMap();
        CreateMap<ClaimArgument, ClaimModel>().ReverseMap();
        CreateMap<TokenArgument, TokenModel>().ReverseMap();
    }
}