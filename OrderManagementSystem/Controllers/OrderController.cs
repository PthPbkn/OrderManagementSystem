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
            if (ModelState.IsValid && viewModel.Order != null && viewModel.OrderDetails != null) 
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

                if (ordrResult == 1 && detailsResult != 0)
                {
                    return Json(new { success = true, redirectToUrl=Url.Action("Index","Order")});
                }
                else
                {
                    return Json(new { success = false, message = "Failed to save invoice!" });
                }
            }
            //return RedirectToAction("Index");
            return Json(new { success = false, message = "Empty invoice" });
        }
      
        public async Task<IActionResult> Index() 
        {
            var invoice = await _orderRepository.GetInvoices();
            return View(invoice);
            
        }

        public async Task<IActionResult> Details(int id)
        {
            List<OrderViewModel> model = new();
            
            var orderData = await _orderRepository.GetOrder(id);
            ViewBag.InvoiceID = orderData.InvoiceID;
            ViewBag.CustomerName = orderData.CustomerName;
            ViewBag.Address = orderData.Address;
            ViewBag.City = orderData.City;
            ViewBag.PostCode = orderData.PostCode;
            ViewBag.Phone = orderData.Phone;
            ViewBag.OrderDate = orderData.OrderDate;
            ViewBag.SubTotal = orderData.SubTotal;
            ViewBag.Tax = orderData.Tax;
            ViewBag.Discount = orderData.Discount;
            ViewBag.TotalAmount = orderData.TotalAmount;

            var data = await _orderDetailsRepository.GetOrderDetails(id);
            foreach (var item in data) 
            {
                OrderViewModel orderDetails = new OrderViewModel()
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ItemTotal = item.ItemTotal,
                };
                model.Add(orderDetails);                
            }
            
            //await _orderDetailsRepository.GetOrderDetails(id);
            return View(model);
        }

        public async Task<int> GetInvoiceNumber()
        {
            var invoiceNumber = await _orderRepository.GetLargestInvoiceNumber();
            return invoiceNumber;
        }
    }
}
