using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IToastNotification _toastNotification;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ISupplierRepository supplierRepository,
            IInvoiceRepository invoiceRepository,
            IProductRepository productRepository,
            IToastNotification toastNotification,
            IOrderRepository orderRepository)
        {
            
            this._supplierRepository = supplierRepository;
            this._invoiceRepository = invoiceRepository;
            this._productRepository = productRepository;
            this._toastNotification = toastNotification;
            this._orderRepository = orderRepository;
        }
       

        // Populate Supplier Name dropdown list
        public async Task<List<SelectListItem>> GetSuppliers()
        {
            var suppliersList = new List<SelectListItem>();
            var suppliers = await _orderRepository.GetSuppliers();
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
            var suppliers = await _orderRepository.GetSupplierById(Id);
            //viewModel.ProductsList = await GetProducts(10);
            return Json(suppliers);
        }


        // Populate Products name dropdown list by Supplier ID
        [HttpGet]
        public async Task<IActionResult> GetProducts(int Id)
        {
            var productList = await _orderRepository.GetProductsBySupplierId(Id);
            return Json(productList);
            
        }

        // Get product details
        [HttpGet]
        public async Task<IActionResult> GetProductDetails(int Id) 
        { 
            var details = await _orderRepository.GetProductsByID(Id);
            return Json(details);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //InvoiceViewModel viewModel = new InvoiceViewModel();
            OrderViewModel viewModel = new OrderViewModel();
            ViewBag.Date = DateTime.Now.ToString("MMMM dd,yyyy");
            viewModel.SupplierList = await GetSuppliers();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            //Invoice invoice = new()
            Order order = new()
            {
                InvoiceID = model.InvoiceID,
                //ProductID = model.ProductID,
                //SupplierID = model.SupplierId,
                //UnitsOrdered = model.Quantity,
                //Amount = model.ItemTotal,
                //SubTotal = model.SubTotal,
                //Tax=model.Tax,
                //TotalAmt = model.TotalAmt,
            };
            var result = await _orderRepository.AddInvoice(order);
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
            var invoice = await _orderRepository.GetInvoices();
            return View(invoice);
            
        }
    }
}
