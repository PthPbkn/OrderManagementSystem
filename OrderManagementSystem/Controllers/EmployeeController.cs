using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IToastNotification _toastNotification;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository repository,
            IToastNotification toastNotification,
            IDepartmentRepository departmentRepository)
        {
            this._repository = repository;
            this._toastNotification = toastNotification;
            this._departmentRepository = departmentRepository;
        }


        public async Task<IActionResult> Index()
        {
            var employees = await _repository.GetAllEmployees();
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            Employee employee = new Employee();
            employee.DepartmentList = await GetDepartments();
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp) 
        {
            if (ModelState.IsValid) 
            {
                var result = await _repository.AddEmployee(emp);
                if (result == 1)
                {
                    _toastNotification.AddSuccessToastMessage("Record created successfully");
                    return RedirectToAction("Index");
                }
                _toastNotification.AddErrorToastMessage("Record not created");
                return View(emp);
            }
            emp.DepartmentList = await GetDepartments();
            return View(emp);
        }

        public async Task<List<SelectListItem>> GetDepartments() 
        {
            var selectList = new List<SelectListItem>();
            var departments = await _departmentRepository.GetAllDepartments();
            foreach ( var department in departments ) 
            { 
                selectList.Add(new SelectListItem { Text = department.DepartmentName,Value=department.DepartmentID.ToString()}); 
            }
            return selectList;
        }

    }
}
