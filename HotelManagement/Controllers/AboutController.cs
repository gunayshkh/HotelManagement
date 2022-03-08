using HotelManagement.Models.DAL;
using HotelManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class AboutController : Controller
    {
        private readonly HotelDbContext _context;
        public AboutController(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ceo = await _context.Employees.Where(p => p.Position == "CEO").FirstOrDefaultAsync();
            var result = await _context.Employees.Where(p => p.Position != "CEO").ToListAsync();
            var servicesList = await _context.Services.ToListAsync();
            var vm = new AboutViewModel()
            {
                CEO = ceo,
                Team = result,
                Services = servicesList,

            };
            return View(vm);
        }
    }
}
