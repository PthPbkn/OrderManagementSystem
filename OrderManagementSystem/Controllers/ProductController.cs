using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Services.Repository;

namespace OrderManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductRepository productRepository,
            IToastNotification toastNotification)
        {
            this._productRepository = productRepository;
            this._toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create() 
        {
         return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid) 
            {
                var result = await _productRepository.AddProduct(product);
                if (result == 1)
                {
                    _toastNotification.AddSuccessToastMessage("New product added successfully");
                    return RedirectToAction("Index");
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Product record is not created");
                    return View(product);
                }
            }            
            return View(product);
        }

        
    }
}
