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
        private readonly IProductRepository _productRepository;

        public InvoiceController(ISupplierRepository supplierRepository,
            IInvoiceRepository invoiceRepository,
            IProductRepository productRepository)
        {
            
            this._supplierRepository = supplierRepository;
            this._invoiceRepository = invoiceRepository;
            this._productRepository = productRepository;
        }
        public async Task<IActionResult> Invoice()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel();
            ViewBag.Date = DateTime.Now.ToString("MMMM dd,yyyy");
            viewModel.SupplierList = await GetSuppliers();
            viewModel.ProductsList = await GetProducts(10);
            return View(viewModel);
        }

        // Populate Supplier Name dropdown list
        public async Task<List<SelectListItem>> GetSuppliers()
        {
            var suppliersList = new List<SelectListItem>();
            var suppliers = await _invoiceRepository.GetSuppliers();
            foreach (var supplier in suppliers)
            {
                suppliersList.Add(new SelectListItem { Text = supplier.SupplierName, Value = supplier.SupplierId.ToString() });
            }
            return suppliersList;
        }
        [HttpGet]

        //Get supplier details by Supplier ID
        public async Task<IActionResult> GetSupplierById(int Id) 
        {
            var suppliers = await _invoiceRepository.GetSupplierById(Id);
            //viewModel.ProductsList = await GetProducts(Id);
            return Json(suppliers);
        }       

        
        // Populate Products name dropdown list by Supplier ID
        public async Task<List<SelectListItem>> GetProducts(int Id) 
        {
            var productList = new List<SelectListItem>();
            var products = await _invoiceRepository.GetProductsBySupplierId(Id);
            foreach (var product in products)
            {
                productList.Add(new SelectListItem { Text = product.ProductName, Value = product.ProductID.ToString() });
            }
            return productList;
        }

        // Get product details
        [HttpGet]
        public async Task<IActionResult> GetProductDetails(int Id) 
        { 
            var details = await _invoiceRepository.GetProductsByID(Id);
            return Json(details);
        }
    }
}
