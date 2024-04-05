using InventoryAPI.Domain.Models;


namespace InventoryAPI.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
}