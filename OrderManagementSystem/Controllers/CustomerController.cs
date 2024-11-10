using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IToastNotification _toastNotification;

        public CustomerController(ICustomerRepository repository,
            IToastNotification toastNotification)
        {
            this._repository = repository;
            this._toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var customer = await _repository.GetAllCustomers();
            return View(customer);
        }
    }
}
