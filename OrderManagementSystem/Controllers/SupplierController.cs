using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IToastNotification _toastNotification;

        public SupplierController(ISupplierRepository supplierRepository,
            IToastNotification toastNotification)
        {
            this._supplierRepository = supplierRepository;
            this._toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()         
        { 
            var supplier = await _supplierRepository.GetAllSupplier();
            return View(supplier);
        }

        [HttpGet]
        public IActionResult Create()         
        {
            //Supplier supplier = new Supplier();
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var result = await _supplierRepository.AddSupplier(supplier);
                if (result == 1)
                {
                    _toastNotification.AddSuccessToastMessage("New supplier added");
                    return RedirectToAction("Index");
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Supplier not added");
                    return View(result);
                }
            }            
            return View(supplier);
        }
    }
}
