using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using NToastNotify;
using OrderManagementSystem.Entity.Data;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.Security;
using OrderManagementSystem.Entity.ViewModels;
using OrderManagementSystem.Services.Repository;

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
            ApplicationUser applicationUser = new ApplicationUser();  //...........?
            ViewBag.Date = DateTime.Now.ToString("MMMM dd,yyyy");
            viewModel.SupplierList = await GetSuppliers();
            viewModel.CustomersList = await GetCustomers();
            //viewModel.UserName = applicationUser.UserName; // ..............?
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = User.Identity.Name;
            //}

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel viewModel)
        {
            //if (ModelState.IsValid) 
            //{
                Order order = new();
                var result = await _orderRepository.AddInvoice(order);
                if (viewModel.OrderDetails != null) 
                {
                    foreach (var items in viewModel.OrderDetails)
                    {
                        items.OrderID = order.OrderID;
                        //items.InvoiceID = order.InvoiceID;
                        await _orderDetailsRepository.AddInvoiceDetails(items);
                    }                
                }
                
                if (result == 1)
                {
                    _toastNotification.AddSuccessToastMessage("Invoice created");
                }

            //}
            return Json(new { success = false, message = "Failed to save the order." });
            //return View();
        }
      
        public async Task<IActionResult> Index() 
        {
            var invoice = await _orderRepository.GetInvoices();
            return View(invoice);
            
        }
    }
}
