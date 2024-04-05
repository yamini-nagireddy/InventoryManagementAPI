using InventoryAPI.Domain.Models;


namespace InventoryAPI.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
}