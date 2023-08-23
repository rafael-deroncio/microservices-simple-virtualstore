using AutoMapper;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Configurations.Mappers.Profiles;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<ProductModel, ProductResponse>()
            .ForPath(dest => dest.Category.Id,
                    opts => opts.MapFrom(src => src.CategoryId)).ReverseMap();

        CreateMap<CategoryModel, CategoryResponse>().ReverseMap();
    }
}