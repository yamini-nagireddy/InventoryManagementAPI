using InventoryAPI.Domain.Repositories;
using InventoryAPI.Domain.Models;
using InventoryAPI.Domain.Services;

namespace InventoryAPI.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }
}