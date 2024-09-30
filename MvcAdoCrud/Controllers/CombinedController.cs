using Microsoft.AspNetCore.Mvc;
using MvcAdoCrud.Data;
using MvcAdoCrud.Models;

namespace MvcAdoCrud.Controllers
{
    public class CombinedController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly CustomerProductRepository _customerProductRepository;

        public CombinedController(ProductRepository productRepository, CustomerRepository customerRepository, CustomerProductRepository customerProductRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _customerProductRepository = customerProductRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            var customers = _customerRepository.GetAllCustomers();
            var customerProducts = _customerProductRepository.GetAllCustomerProduct();

            var model = new Tuple<List<Product>, List<Customer>, List<CustomerProduct>>(products, customers, customerProducts);
            return View(model);
        }
    }
}
