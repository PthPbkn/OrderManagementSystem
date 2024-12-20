using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
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
        private readonly IToastNotification _toastNotification;

        public InvoiceController(ISupplierRepository supplierRepository,
            IInvoiceRepository invoiceRepository,
            IProductRepository productRepository,
            IToastNotification toastNotification)
        {
            
            this._supplierRepository = supplierRepository;
            this._invoiceRepository = invoiceRepository;
            this._productRepository = productRepository;
            this._toastNotification = toastNotification;
        }
        //public async Task<IActionResult> Invoice()
        //{
        //    InvoiceViewModel viewModel = new InvoiceViewModel();
        //    ViewBag.Date = DateTime.Now.ToString("MMMM dd,yyyy");
        //    viewModel.SupplierList = await GetSuppliers();
        //    return View(viewModel);
        //}

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
            //viewModel.ProductsList = await GetProducts(10);
            return Json(suppliers);
        }


        // Populate Products name dropdown list by Supplier ID
        [HttpGet]
        public async Task<IActionResult> GetProducts(int Id)
        {
            var productList = await _invoiceRepository.GetProductsBySupplierId(Id);
            return Json(productList);
            
        }

        // Get product details
        [HttpGet]
        public async Task<IActionResult> GetProductDetails(int Id) 
        { 
            var details = await _invoiceRepository.GetProductsByID(Id);
            return Json(details);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            InvoiceViewModel viewModel = new InvoiceViewModel();
            ViewBag.Date = DateTime.Now.ToString("MMMM dd,yyyy");
            viewModel.SupplierList = await GetSuppliers();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            Invoice invoice = new()
            {
                InvoiceId = model.InvoiceId,
                ProductId = model.ProductID,
                SupplierId = model.SupplierId,
                UnitsOrdered = model.UnitsOnOrder,
                Amount = model.Amount,
                SubTotal = model.SubTotal,
                Tax=model.Tax,
                TotalAmt = model.TotalAmt,
            };
            var result = await _invoiceRepository.AddInvoice(invoice);
            if (result == 1)
            {
                _toastNotification.AddSuccessToastMessage("Invoice created successfully");
                return RedirectToAction("Index");
            }
            _toastNotification.AddErrorToastMessage("Invoice not saved!");
            return View(Index);
        }

        public async Task<IActionResult> Index() 
        {
            var invoice = await _invoiceRepository.GetInvoices();
            return View(invoice);
            
        }
    }
}
