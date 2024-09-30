using Microsoft.AspNetCore.Mvc;
using MvcAdoCrud.Data;
using MvcAdoCrud.Models;

namespace MvcAdoCrud.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _customerrepository;
        public CustomersController(CustomerRepository customerRepository)
        {
            _customerrepository = customerRepository;
        }
        public IActionResult Index()
        {
            var customer = _customerrepository.GetAllCustomers();
            return View(customer);
        }
        public IActionResult Details(int id)
        {
            var customer = _customerrepository.GetCustomerById(id);
            if(customer == null) 
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerrepository.Addcustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public IActionResult Edit(int id)
        {
            var customer = _customerrepository.GetCustomerById(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerrepository.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerrepository.GetCustomerById(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _customerrepository.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}