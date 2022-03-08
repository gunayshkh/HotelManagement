using HotelManagement.Models.DAL;
using HotelManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly HotelDbContext _db;

        public HotelController(HotelDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var hotels = await _db.Hotels.Where(h => !h.IsDeleted).Include(h => h.HotelType).OrderBy(p => p.StarCount).Select(s => new Hotel
            {
                Id = s.Id,
                Name = s.Name,
                StarCount = s.StarCount,
                Description = s.Description,
                HotelType = s.HotelType,
                ImageURL = s.ImageURL
            }).ToListAsync();
            return View();
        }
    }
}
