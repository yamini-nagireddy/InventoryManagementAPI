

namespace InventoryAPI.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}