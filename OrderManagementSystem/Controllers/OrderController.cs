using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using NToastNotify;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.Security;
using OrderManagementSystem.Entity.ViewModels;
using OrderManagementSystem.Services.Repository;
using System.Security.Claims;

namespace OrderManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IToastNotification _toastNotification;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(ISupplierRepository supplierRepository,
            IProductRepository productRepository,
            IToastNotification toastNotification,
            IOrderRepository orderRepository,
            IOrderDetailsRepository orderDetailsRepository,
            ICustomerRepository customerRepository)
        {
            
            this._supplierRepository = supplierRepository;
            this._productRepository = productRepository;
            this._toastNotification = toastNotification;
            this._orderRepository = orderRepository;
            this._orderDetailsRepository = orderDetailsRepository;
            this._customerRepository = customerRepository;
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

        public async Task<List<SelectListItem>> GetCustomers()
        {
            var customersList = new List<SelectListItem>();
            var customers = await _customerRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                customersList.Add(new SelectListItem { Text = customer.CustomerName, Value = customer.CustomerId.ToString() });
            }
            return customersList;
        }

        [HttpGet]
        //Get supplier details by Supplier ID
        public async Task<IActionResult> GetSupplierById(int Id) 
        {
            var suppliers = await _orderRepository.GetSupplierById(Id);
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
            OrderViewModel viewModel = new OrderViewModel();
            ViewBag.Date = DateTime.Now.ToString("MMMM dd,yyyy");
            ViewBag.DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);            
            viewModel.SupplierList = await GetSuppliers();
            viewModel.CustomersList = await GetCustomers();
            viewModel.InvoiceID = await GetInvoiceNumber();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel viewModel)
        {

            if (ModelState.IsValid && viewModel.Order != null) 
            {
                var detailsResult = 0;
                var ordrResult = await _orderRepository.AddInvoice(viewModel.Order);
                if (viewModel.OrderDetails != null)
                {
                    viewModel.OrderDetails.ToList().ForEach(items =>
                    {
                        items.OrderID = viewModel.Order.OrderID;
                        items.InvoiceID = viewModel.Order.InvoiceID;
                    });
                    detailsResult = await _orderDetailsRepository.AddInvoiceDetails(viewModel.OrderDetails);

                }

                if (ordrResult == 1 && detailsResult == 1)
                {
                   _toastNotification.AddSuccessToastMessage("Invoice created");
                 
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Failed to create invoice!");
                }
            }
            return Json(new { success = true, message = "Invoice saved successfully!" });
        }
      
        public async Task<IActionResult> Index() 
        {
            var invoice = await _orderRepository.GetInvoices();
            return View(invoice);
            
        }

        public async Task<IActionResult> Details(int id)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            var invoice = await _orderRepository.GetOrder(id);
            //orderViewModel.OrderDetails = await _orderDetailsRepository.GetOrderDetails(id);
           await _orderDetailsRepository.GetOrderDetails(id);
            return View(invoice);
        }

        public async Task<int> GetInvoiceNumber()
        {
            var invoiceNumber = await _orderRepository.GetLargestInvoiceNumber();
            return invoiceNumber;
        }
    }
}
