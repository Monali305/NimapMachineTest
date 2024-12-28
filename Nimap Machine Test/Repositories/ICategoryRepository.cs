using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.ViewModels;

namespace Nimap_Machine_Test.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryViewModel> GetByIdAsync(int id);
        Task<List<CategoryViewModel>> GetAllAsync();
        Task AddAsync(CategoryViewModel category);
        Task UpdateAsync(CategoryViewModel category);
        Task DeleteAsync(int Id);
    }
}
