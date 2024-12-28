using Microsoft.EntityFrameworkCore;
using Nimap_Machine_Test.Data;
using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.ViewModels;

namespace Nimap_Machine_Test.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppdbContext _dbContext;
        public CategoryRepository(AppdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                throw new ArgumentException("Invalid CategoryId. Category does not exist.");
            }
            var categoryviewmodel = new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return categoryviewmodel;
        }
        public async Task AddAsync(CategoryViewModel category)
        {
            var newCategory = new Category()
            {
                CategoryName = category.CategoryName
            };
            await _dbContext.Categories.AddAsync(newCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var category = await _dbContext.Categories.FindAsync(Id);
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            List<Category> categories = await _dbContext.Categories.ToListAsync();
            List<CategoryViewModel> categoryviewmodels = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                var categoryviewmodel = new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                categoryviewmodels.Add(categoryviewmodel);
            }

            return categoryviewmodels;
        }
        public async Task UpdateAsync(CategoryViewModel categoryupdated)
        {
            var category = await _dbContext.Categories.FindAsync(categoryupdated.CategoryId);
            if (category == null)
            {
                throw new ArgumentException("Invalid CategoryId. Category does not exist.");
            }
            category.CategoryName = categoryupdated.CategoryName;

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
