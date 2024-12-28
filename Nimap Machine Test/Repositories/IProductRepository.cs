using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.ViewModels;

namespace Nimap_Machine_Test.Repositories
{
    public interface IProductRepository
    {
        Task<ProductViewModel> GetByIdAsync(int id);
        IQueryable<ProductViewModel> GetAllAsync();
        Task AddAsync(ProductViewModel product);
        Task UpdateAsync(ProductViewModel product);
        Task DeleteAsync(int Id);

        Task<List<Category>> GetAllCategories();
    }
}
