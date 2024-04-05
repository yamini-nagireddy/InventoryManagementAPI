using AutoMapper;
using InventoryAPI.Domain.Models;
using InventoryAPI.Resources;
using InventoryAPI.Extensions;

namespace InventoryAPI.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
    }
}