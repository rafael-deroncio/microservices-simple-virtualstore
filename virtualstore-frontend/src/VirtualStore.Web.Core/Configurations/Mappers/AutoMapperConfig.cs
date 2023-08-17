using AutoMapper;
using VirtualStore.Web.Core.Configurations.Mappers.Profiles;

namespace VirtualStore.Web.Core.Configurations.Mappers;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new RequestToViewModelProfile());
                cfg.AddProfile(new ResponseToViewModelProfile());
            });
    }
}