using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Entity.Data;

namespace OrderManagementSystem.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
