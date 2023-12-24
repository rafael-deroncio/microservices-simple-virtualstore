using AutoMapper;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Domain.Requests;

namespace VirtualStore.Identity.Core.Configurations.Mappers.Profiles;

public class RequestToArgumentProfile : Profile
{
    public RequestToArgumentProfile()
    {
        CreateMap<PaginationRequest, PaginationArgument>().ReverseMap();
        CreateMap<UserArgument, UserRequest>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            .ReverseMap();
        CreateMap<AddressArgument, AddressRequest>().ReverseMap();
        CreateMap<TelephoneArgument, TelephoneRequest>().ReverseMap();
    }
}