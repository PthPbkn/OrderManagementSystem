using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using OrderManagementSystem.Entity.Models;
using OrderManagementSystem.Entity.ViewModels;
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
                if(product.file != null)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
                    int newProductId = await _productRepository.GetLargerProductId() + 1;
                    if (newProductId > 0) 
                    {
                        fileName = newProductId + ".jpeg";
                        string imagePath = Path.Combine(path, fileName);
                        using (var fileStream = new FileStream(imagePath, FileMode.Create))
                        {
                            product.file.CopyTo(fileStream);
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

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetProductById(id);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductByIdForEdit(id);
            product.SupplierList = await GetAllSuppliers();
            product.CategoryList = await GetAllCategoryName();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product) 
        {
            var status = 0;
            if (ModelState.IsValid)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImages");
                if (product.ProductId > 0)
                {
                    var fileName = product.ProductId + ".jpg";
                    string imagePath = Path.Combine(path, fileName);
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))                        
                    {
                        //System.IO.File.Exists(imagePath)
                        product.file?.CopyTo(fileStream);
                    }
                    product.ImagePath = fileName;
                    status = await _productRepository.UpdateProduct(product);
                    if (status == 1)
                    {
                        _toastNotification.AddSuccessToastMessage("Record Updated");
                        return RedirectToAction("Index");
                    }
                    _toastNotification.AddErrorToastMessage("Record not saved");
                    return View(product);
                }
            }
            _toastNotification.AddErrorToastMessage("Record not saved");
            return View(product);   
        }

        [HttpPost]
        public async Task<JsonResult> Discontinue(int prodId)        
        {
            var status = await _productRepository.ContinueDiscontinueProduct(prodId);

            if (status == 1)
            {
                _toastNotification.AddSuccessToastMessage("Product status changed");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Somthing wrong, Nothing updated");
            }
            
            return Json(new { success = true, message = "Product status updated" });
        }
        
    }
}
