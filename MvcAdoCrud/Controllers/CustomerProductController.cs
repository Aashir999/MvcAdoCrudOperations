using Microsoft.AspNetCore.Mvc;
using MvcAdoCrud.Data;
using MvcAdoCrud.Models;
namespace MvcAdoCrud.Controllers
{
    public class CustomerProductController : Controller
    {
        private readonly CustomerProductRepository _repository;
        public CustomerProductController(CustomerProductRepository customerproductrepository)
        {
            _repository = customerproductrepository;
        }


        // GET: CustomerProduct
        public IActionResult Index()
        {
            var customerProducts = _repository.GetAllCustomerProduct();
            return View(customerProducts);
        }

        // GET: CustomerProduct/Details/5
        public IActionResult Details(int customerId, int id)
        {
            var customerProduct = _repository.GetCustomerProductById(id, customerId);
            if (customerProduct == null)
            {
                return NotFound();
            }
            return View(customerProduct);
        }

        // GET: CustomerProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerProduct customerProduct)
        {
            if (ModelState.IsValid)
            {
                _repository.AddCustomerProduct(customerProduct);
                return RedirectToAction(nameof(Index));
            }
            return View(customerProduct);
        }

        // GET: CustomerProduct/Edit/5
        public IActionResult Edit(int customerId, int id)
        {
            var customerProduct = _repository.GetCustomerProductById(id, customerId);
            if (customerProduct == null)
            {
                return NotFound();
            }
            return View(customerProduct);
        }

        // POST: CustomerProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerProduct customerProduct)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateCustomerProduct(customerProduct);
                return RedirectToAction(nameof(Index));
            }
            return View(customerProduct);
        }

        // GET: CustomerProduct/Delete/5
        public IActionResult Delete(int customerId, int id)
        {
            var customerProduct = _repository.GetCustomerProductById(id, customerId);
            if (customerProduct == null)
            {
                return NotFound();
            }
            return View(customerProduct);
        }

        // POST: CustomerProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int customerId, int id)
        {
            _repository.DeleteCustomerProduct(customerId, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
