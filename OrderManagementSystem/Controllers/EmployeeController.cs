using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IToastNotification _toastNotification;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICountryRespository _countryRespository;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository repository,
            IToastNotification toastNotification,
            IDepartmentRepository departmentRepository,
            ICountryRespository countryRespository,
            IWebHostEnvironment env)
            
        {
            this._repository = repository;
            this._toastNotification = toastNotification;
            this._departmentRepository = departmentRepository;
            this._countryRespository = countryRespository;
            this._env = env;
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
            employee.CountryList = await GetCountryNames();
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp) 
        {
            string fileName = string.Empty;
            if (ModelState.IsValid) 
            {
                if(emp.file != null)
                {
                    string path = Path.Combine(_env.WebRootPath, "Images");
                    //can not create image with EmployeeID as ID not assigned when creating new record.!
                    fileName = Guid.NewGuid().ToString() + ".jpeg";
                    string imagePath = Path.Combine(path,fileName);
                    using(var fileStream = new FileStream(imagePath,FileMode.Create))
                    {
                        emp.file.CopyTo(fileStream);                        
                    }
                    emp.ImagePath = fileName;                       
                }
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
            emp.CountryList = await GetCountryNames();
            return View(emp);

        }

        public async Task<IActionResult> Details(int id)
        { 
            var employee = await _repository.GetEmployeeByEmployeeID(id);            
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _repository.GetEmployeeByID(id);
            employee.DepartmentList = await GetDepartments();
            employee.CountryList = await GetCountryNames();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {             
            if (emp.file != null)
            {
                string path = Path.Combine(_env.WebRootPath, "Images");
                string fileName = Guid.NewGuid().ToString() + ".jpeg";
                string imagePath = Path.Combine(path, fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    emp.file.CopyTo(fileStream);
                }
                emp.ImagePath = fileName;
            }
            await _repository.UpdateEmployeeByEmployeeID(emp);
            //how to do error response check?
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _repository.GetEmployeeByEmployeeID(id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _repository.DeleteEmployeeByEmployeeID(id);
            _toastNotification.AddSuccessToastMessage("Employee record deleted!");
            return RedirectToAction("Index");                                     
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

        public async Task<List<SelectListItem>> GetCountryNames() 
        {
            var countryList = new List<SelectListItem>();
            var countries = await _countryRespository.GetCountries();
            foreach( var country in countries )
            {
                countryList.Add(new SelectListItem { Text = country.CountryName, Value=country.CountryID.ToString()});
            }
            return countryList;

        }

        

               

    }
}


// Toast is not working
// add modal popup for delete record
