using HotelManagement.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ServicesController : Controller
    {

        private readonly HotelDbContext _context;
        public ServicesController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
