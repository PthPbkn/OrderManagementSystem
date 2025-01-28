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
        private readonly ISupplierRepository _supplierRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepository,
            IToastNotification toastNotification,
            ISupplierRepository supplierRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment
            )
        {
            this._productRepository = productRepository;
            this._toastNotification = toastNotification;
            this._supplierRepository = supplierRepository;
            this._categoryRepository = categoryRepository;
            this._webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public async Task <IActionResult> Create() 
        {
            Product product = new Product();
            product.CategoryList = await GetAllCategoryName();
            product.SupplierList = await GetAllSuppliers();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            string fileName = string.Empty;
            var result = 0;
            if (ModelState.IsValid) 
            {
                if(product.File != null)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
                    int newProductId = await _productRepository.GetLargerProductId() + 1;
                    if (newProductId > 0) 
                    {
                        fileName = newProductId + ".jpeg";
                        string imagePath = Path.Combine(path, fileName);
                        using (var fileStream = new FileStream(imagePath, FileMode.Create))
                        {
                            product.File.CopyTo(fileStream);
                        }
                        product.ImagePath = fileName;
                        product.ProductId = newProductId;
                        result = await _productRepository.AddProduct(product);
                    }
                }
                
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

        public async Task<List<SelectListItem>> GetAllCategoryName() 
        {
            var selectList = new List<SelectListItem>();
            var category = await _categoryRepository.GetAllCategory();
            foreach (var categoryItem in category) 
            {
                selectList.Add(new SelectListItem { Text = categoryItem.CategoryName, Value = categoryItem.CategoryId.ToString() });
            }
            return selectList;

        }

        public async Task<List<SelectListItem>> GetAllSuppliers()
        {
            var selectList = new List<SelectListItem>();
            var supplier = await _supplierRepository.GetAllSupplier();
            foreach (var supplierItem in supplier)
            {
                selectList.Add(new SelectListItem { Text = supplierItem.SupplierName, Value = supplierItem.SupplierId.ToString() });
            }
            return selectList;
        }
        
    }
}
