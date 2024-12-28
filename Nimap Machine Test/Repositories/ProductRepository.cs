using Microsoft.EntityFrameworkCore;
using Nimap_Machine_Test.Data;
using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.ViewModels;

namespace Nimap_Machine_Test.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppdbContext _dbContext;
        public ProductRepository(AppdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ProductViewModel product)
        {
            var category = await _dbContext.Categories.FindAsync(product.CategoryId);
            if (category == null)
            {
                throw new ArgumentException("Invalid CategoryId. Category does not exist.");
            }
            var newProduct = new Product()
            {
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                CategoryName = category.CategoryName
            };
            await _dbContext.Products.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var product = await _dbContext.Products.FindAsync(Id);
            if (product == null)
            {
                throw new ArgumentException($"Product with ID {Id} not found.");
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<ProductViewModel> GetAllAsync()
        {
            var products = _dbContext.Products
            .Select(e => new ProductViewModel
            {
                ProductId = e.ProductId,
                ProductName = e.ProductName,
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName
            });
            
            return products;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Product with ID {id} not found.");
            }
            var productviewmodel = new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName
            };
            return productviewmodel;
        }

        public async Task UpdateAsync(ProductViewModel productupdated)
        {
            var product = await _dbContext.Products.FindAsync(productupdated.ProductId);
            if (product == null)
            {
                throw new ArgumentException($"Product with ID {productupdated.ProductId} not found.");
            }
            var category = await _dbContext.Categories.FindAsync(productupdated.CategoryId);
            if (category == null)
            {
                throw new ArgumentException($"Category with ID {productupdated.CategoryId} not found.");
            }
            product.ProductName = productupdated.ProductName;
            product.CategoryId = productupdated.CategoryId;
            product.CategoryName = category.CategoryName;
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
