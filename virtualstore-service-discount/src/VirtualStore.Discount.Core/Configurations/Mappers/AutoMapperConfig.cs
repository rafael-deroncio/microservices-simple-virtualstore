using AutoMapper;
using VirtualStore.Discount.Core.Configurations.Mappers.Profiles;

namespace VirtualStore.Discount.Core.Configurations.Mappers;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(
            cfg => { 
                cfg.AddProfile(new RequestToResponseProfile());
                cfg.AddProfile(new RequestToArgumentProfile());
                cfg.AddProfile(new ModelToResponseProfile());
                cfg.AddProfile(new ModelToArgumentProfile());
            });
    }
}