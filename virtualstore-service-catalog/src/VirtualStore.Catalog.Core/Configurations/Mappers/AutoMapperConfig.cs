using AutoMapper;
using VirtualStore.Catalog.Core.Configurations.Mappers.Profiles;

namespace VirtualStore.Catalog.Core.Configurations.Mappers;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(
            cfg => { 
                cfg.AddProfile(new RequestoToResponseProfile());
                cfg.AddProfile(new RequestToArgumentProfile());
                cfg.AddProfile(new ModelToResponseProfile());
            });
    }
}