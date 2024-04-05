using InventoryAPI.Persistence.Contexts;
using InventoryAPI.Domain.Repositories;

namespace InventoryAPI.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}