using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.Repositories;
using Nimap_Machine_Test.ViewModels;

namespace Nimap_Machine_Test.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            var products = _productRepository.GetAllAsync();

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            int pageSize = 5;
            return View(await PaginatedList<ProductViewModel>.CreateAsync((IQueryable<ProductViewModel>)products, pageNumber, pageSize));
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _productRepository.GetAllCategories();
            ViewBag.Category = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _productRepository.AddAsync(model);
            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _productRepository.GetAllCategories();
            ViewBag.Category = new SelectList(categories, "CategoryId", "CategoryName");
            var product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _productRepository.UpdateAsync(product);

            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index", "Product");
        }
    }
}
