using Domain.Entities;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Generator.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDataBaseService _customerService;
        public CustomerController(IDataBaseService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {

            //if (!this.GetType().Equals(customer.GetType()))
            //{
            //    return View("Error/Error");
            //}
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            var id = _customerService.Save(customer);
            TempData["CustomerId"] = id; // tu zapis. Wywołanie w widoku
            return RedirectToAction("Add");
        }

        [Route("CustomerList")]
        public IActionResult CustomerList(Customer customer)
        {
            var lst = _customerService.GetAll();
            return View(lst);
        }

        [HttpGet]
        public IActionResult DetailsCustomer(int id)
        {
            var detail = _customerService.Get(id);
            return View(detail);
        }

        [HttpPost]
        public IActionResult DeleteCustomers(int id)
        {
            _customerService.DeleteCustomers(id);
            return RedirectToAction("CustomerList");
        }
        public async Task<IActionResult> Search(string searchString)
        {
            if (_customerService.Search == null)
            {
                return Problem("Customer isn't at the database");
            }
            var customer = await _customerService.Search(searchString);

            return View(customer);
        }
    }
}

