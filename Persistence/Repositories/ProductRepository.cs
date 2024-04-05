using Microsoft.EntityFrameworkCore;
using InventoryAPI.Domain.Models;
using InventoryAPI.Persistence.Contexts;
using InventoryAPI.Domain.Repositories;

namespace InventoryAPI.Persistence.Repositories;

public class ProductRepository: BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.Include(p => p.Category)
                                        .ToListAsync();
    }
}