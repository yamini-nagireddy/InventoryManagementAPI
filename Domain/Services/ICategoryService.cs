using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryAPI.Domain.Models;
using InventoryAPI.Domain.Services.Communication;

namespace InventoryAPI.Domain.Services;
public interface ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int id, Category category);
    Task<CategoryResponse> DeleteAsync(int id);

}