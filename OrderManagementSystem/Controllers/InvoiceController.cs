using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(ISupplierRepository supplierRepository,
            IInvoiceRepository invoiceRepository)
        {
            
            this._supplierRepository = supplierRepository;
            this._invoiceRepository = invoiceRepository;
        }
        public async Task<IActionResult> Invoice()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel();
            //Supplier supplier = new Supplier();
            //supplier.SupplierList = await GetSuppliers();
            viewModel.SupplierList = await GetSuppliers();
            return View(viewModel);
        }

        public async Task<List<SelectListItem>> GetSuppliers() 
        {
            var suppliersList = new List<SelectListItem>();
            var suppliers = await _supplierRepository.GetAllSupplier();
            foreach ( var supplier in suppliers )
            {
                suppliersList.Add(new SelectListItem { Text = supplier.SupplierName, Value = supplier.SupplierId.ToString() });
                suppliersList.Add(new SelectListItem { Text = supplier.Address });
            }

            return suppliersList;
        }
    }
}
