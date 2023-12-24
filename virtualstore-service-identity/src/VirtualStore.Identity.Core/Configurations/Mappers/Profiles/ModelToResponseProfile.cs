using AutoMapper;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Configurations.Mappers.Profiles;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<RoleModel, RoleResponse>().ReverseMap();
        CreateMap<ClaimModel, ClaimResponse>().ReverseMap();
        CreateMap<TokenModel, TokenResponse>().ReverseMap();
        CreateMap<LoginModel, LogInResponse>().ReverseMap();
        CreateMap<AddressModel, AddressResponse>().ReverseMap();
        CreateMap<TelephoneModel, TelephoneResponse>().ReverseMap();
    }
}