
using AutoMapper;
using InventoryAPI.Domain.Models;
using InventoryAPI.Resources;

namespace InventoryAPI.Mapping;

public class ResourceToModelProfile: Profile    
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCategoryResource, Category>();
    }
}