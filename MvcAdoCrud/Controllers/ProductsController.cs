using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcAdoCrud.Data;
using MvcAdoCrud.Models;

namespace MvcAdoCrud.Controllers
{
   
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View("ProductsCRUD",products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null) return NotFound();
            return View("ProductsCRUD", product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View("ProductsCRUD", product);
        }
        [HttpGet("Productslisting1243")]
        public List<Product> GetProduct()
        {

            return _productRepository.GetAllProducts();
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null) return NotFound();
            return View("ProductsCRUD", product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View("ProductsCRUD", product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null) return NotFound();
            return View("ProductsCRUD", product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
