using HotelManagement.Areas.Admin.Models.ViewModels.HotelViewModels;
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

        public async Task<IActionResult> Detail(int id)
        {
            var hotels = await _db.Hotels.FindAsync(id);
            if (hotels == null) return NotFound();
            return View(hotels);
        }
        public async Task<IActionResult> Create(CreateHoteViewModel model)
        {
            if (!ModelState.IsValid) return View();
            Hotel hotel = new()
            {
                Name = model.Name,
                Description = model.Description,
                StarCount = model.StarCount
            };

            await _db.Hotels.AddAsync(hotel);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create(int id, Hotel hotel)
        //{
        //    return View(new Hotel  
        //}
    

    }
}
