using HotelManagement.Models.DAL;
using HotelManagement.Models.Entities;
using HotelManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelDbContext _context;
        public HotelsController(HotelDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var hotelTypes = await _context.HotelTypes.ToListAsync();
            var hotels = await _context.Hotels.Where(h => !h.IsDeleted).Include(h=>h.HotelType).OrderBy(p => p.StarCount).Select(s=> new Hotel
            {
                Id = s.Id,
                Name = s.Name,
                StarCount = s.StarCount,
                Description = s.Description,
                HotelType = s.HotelType,
                ImageURL = s.ImageURL
            }).ToListAsync();
            //List<RoomViewModel> rooms =  await _context.Rooms.Where(r => !r.IsDeleted).Select(r => new RoomViewModel
            //{
            //    HotelId = r.HotelId,
            //    RoomDescription = r.RoomDescription,
            //    RoomNo = r.RoomNo

            //}).ToListAsync();

            var vm = new HotelIndexViewModel()
            {
                Hotels = hotels,
                HotelTypes = hotelTypes,
            };
            return View(vm);
        }
    }
}
