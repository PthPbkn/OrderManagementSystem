using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderManagementSystem.Entity.Model;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this._repository = repository;
        }


        public async Task<IActionResult> Index()
        {
            var employees = await _repository.GetAllEmployees();
            return View(employees);
        }


    }
}
