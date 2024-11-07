using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OrderManagementSystem.Entity.ViewModels;

namespace OrderManagementSystem.Controllers
{
    public class AdministrativeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IToastNotification _toastNotification;

        public AdministrativeController(RoleManager<IdentityRole> roleManager,
            IToastNotification toastNotification)
       
        {
            this._roleManager = roleManager;
            this._toastNotification = toastNotification;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var role = new IdentityRole
                { 
                    Name= model.RoleName,
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded) 
                {
                    _toastNotification.AddSuccessToastMessage("Role created.");
                    return RedirectToAction(nameof(ListRole));
                }
            }
            return View();
        }

        public async Task<IActionResult> ListRole() 
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
    }
}
