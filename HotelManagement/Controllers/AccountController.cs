using HotelManagement.DATA;
using HotelManagement.Models.DAL;
using HotelManagement.Models.Entities;
using HotelManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, HotelDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) 
            { 
                ModelState.AddModelError("", "Invalid Credentials"); 
                return View(); 
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.isPersistent, true);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Credentials (pass)");
                return View();
            }


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var dbUser = await _userManager.FindByNameAsync(model.UserName);

            if (dbUser != null)
            {
                ModelState.AddModelError(nameof(RegisterViewModel.UserName),
                    "This User already exists");
                return View();
            }

            User user = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
            };

            var IdentityResult = await _userManager.CreateAsync(user, model.Password);

            if (!IdentityResult.Succeeded)
            {
                foreach (var error in IdentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                } 
                return View();
            }

            await _signInManager.SignInAsync(user, true);
            await _userManager.AddToRoleAsync(user, RoleConstants.User);


            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




    }
}
