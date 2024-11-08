using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OrderManagementSystem.Entity.Security;
using OrderManagementSystem.Entity.ViewModels;

namespace OrderManagementSystem.Controllers
{
    public class AdministrativeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IToastNotification _toastNotification;

        public AdministrativeController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IToastNotification toastNotification)
       
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
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

        public IActionResult ListRole() 
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> AddRemoveRoles(string id) 
        { 
            List<AddRemoveRoleViewModel> models = new();

            var user = await _userManager.FindByIdAsync(id);

            ViewBag.UserName = user.UserName;
            ViewBag.UserID = user.Id;

            foreach (var role in _roleManager.Roles.ToList()) 
            {
                AddRemoveRoleViewModel roleViewModel = new AddRemoveRoleViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };
                models.Add(roleViewModel);
            }
            return View(models); 
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveRoles(List<AddRemoveRoleViewModel> models,string UserId)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(UserId);

                IdentityResult result = new IdentityResult();

                foreach (var role in models) 
                {
                    if (role.IsSelected && !await _userManager.IsInRoleAsync(user, role.RoleName))
                    {
                        result = await _userManager.AddToRoleAsync(user,role.RoleName);
                    }
                    else if (!role.IsSelected && await  _userManager.IsInRoleAsync(user,role.RoleName)) 
                    {

                        result = await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                    }
                }
            }
            return RedirectToAction(nameof(ListUsers));
        }

        public IActionResult ListUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);

        }
    }
}
