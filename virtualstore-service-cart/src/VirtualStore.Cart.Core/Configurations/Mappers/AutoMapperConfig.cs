using AutoMapper;
using VirtualStore.Cart.Core.Configurations.Mappers.Profiles;

namespace VirtualStore.Cart.Core.Configurations.Mappers;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(
            cfg => { 
                cfg.AddProfile(new RequestToResponseProfile());
                cfg.AddProfile(new RequestToArgumentProfile());
                cfg.AddProfile(new ModelToResponseProfile());
            });
    }
}