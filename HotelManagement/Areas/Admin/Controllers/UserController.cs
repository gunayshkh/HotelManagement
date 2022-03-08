using HotelManagement.DATA;
using HotelManagement.Models.DAL;
using HotelManagement.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(RoleConstants.SuperAdmin))]
    public class UserController : Controller
    {
        public readonly HotelDbContext _db;
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
       
        public UserController(HotelDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id)
        {
            return View();
        }
    }
}
