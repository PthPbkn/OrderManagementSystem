using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Entity.Security;
using OrderManagementSystem.Entity.ViewModels;

namespace OrderManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var result = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Employee");
                }

                ModelState.AddModelError(string.Empty, "Invalid Username OR Password");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {   UserName = model.UserName,
                    FirstName = model.FirstName, 
                    LastName = model.LastName,
                    Email = model.Email,
                   
                };
                var result = await _userManager.CreateAsync(user,model.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));  // why nameof??????????????????
                }
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,err.Description);
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
            //return View();

           
        }
    }
}
