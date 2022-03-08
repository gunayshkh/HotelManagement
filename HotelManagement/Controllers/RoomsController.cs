using HotelManagement.Models.DAL;
using HotelManagement.Models.Entities;
using HotelManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class RoomsController : Controller
    {

        private readonly HotelDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RoomsController(HotelDbContext context, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(int? id)
        {
            List<Room> roomList = null;
            if (id!=null)
            {
             roomList = await _context.Rooms.Where(r=>!r.IsDeleted && r.IsActive && r.HotelId== id).ToListAsync();

            }
            else
            {
                roomList = await _context.Rooms.Where(r => !r.IsDeleted && r.IsActive ).ToListAsync();

            }

            return View(roomList);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(RoomSearchViewModel model)
        {
            var roomList = await _context.Rooms.Where(r => !r.IsDeleted && r.IsActive ).ToListAsync();

            return View("Index", roomList);

        }


        [HttpPost]
        
        public async Task<IActionResult> Detail(DetailViewModel model)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction(nameof(AccountController.Login), "Account");
            var roomDetails = await _context.Rooms.FirstOrDefaultAsync(i => i.Id == model.RoomId);
            RoomImage mainImage = await _context.RoomImages.FirstOrDefaultAsync(i => i.IsMain && i.RoomId == roomDetails.Id);
            var servicesList = await _context.Services.ToListAsync();
            var amenities = await _context.Amenities.ToListAsync();

            List<RoomImage> images = await _context.RoomImages.Where(r => !r.IsMain && r.Room.Id == roomDetails.Id).ToListAsync();


            DetailViewModel dvm = new DetailViewModel
            {

                Rooms = roomDetails,
                MainImage = mainImage,
                Services = servicesList,
                Amenities = amenities,
                Images = images,
                avm = new(),
                RoomId = roomDetails.Id,

            };
            if (!ModelState.IsValid) return View(dvm);

            int result = DateTime.Compare(dvm.avm.Checkin, dvm.avm.Checkout);
            //< 0 − If date1 is earlier than date2.
            // 0 − If date1 is the same as date2.
            // > 0 − If date1 is later than date2.

            if (result! < 0)
            {
                ModelState.AddModelError("", "Checkout cannot be earlier than chekin date");
                return View(dvm);
            }

            if (_context.Accomodations.Any(a =>
            (a.Checkin == model.avm.Checkin || a.Checkin == model.avm.Checkout) ||
            (a.Checkout == model.avm.Checkin || a.Checkout == model.avm.Checkout) ||
            (a.Checkin > model.avm.Checkin && a.Checkout < model.avm.Checkout) ||
            (a.Checkin < model.avm.Checkin && a.Checkout > model.avm.Checkout) ||
            (a.Checkout > model.avm.Checkin && a.Checkout < model.avm.Checkout)||
            (a.Checkin > model.avm.Checkin && a.Checkin < model.avm.Checkout)
            ))
            {
                ModelState.AddModelError("", "There is a conflict in a reservations date");
                return View(dvm);
            }

            await _context.Accomodations.AddAsync(new Accomodation
            {
                Checkin = model.avm.Checkin,
                Checkout = model.avm.Checkout,
                Room = roomDetails,
                User = await _userManager.Users.FirstOrDefaultAsync(u=> ClaimTypes.NameIdentifier==u.Id),
                
            });
            await _context.SaveChangesAsync();

            
           


            return RedirectToAction(nameof(Index),new {id=roomDetails.HotelId}) ;

		}
       
        public async Task<IActionResult> Detail(int? id)
        {
            var roomDetails = await _context.Rooms.FirstOrDefaultAsync(i=>i.Id ==id);
            RoomImage mainImage = await _context.RoomImages.FirstOrDefaultAsync(i => i.IsMain && i.RoomId == roomDetails.Id);
            var servicesList = await _context.Services.ToListAsync();
            var amenities = await _context.Amenities.ToListAsync();

            List<RoomImage> images = await _context.RoomImages.Where(r=>!r.IsMain && r.Room.Id == roomDetails.Id).ToListAsync();
                 

            if (roomDetails == null)
            {
                return NotFound();
            }

             DetailViewModel dvm= new DetailViewModel
            {
                
                Rooms = roomDetails,
                MainImage = mainImage,
                Services = servicesList,
                Amenities = amenities, 
                Images = images,
                avm = new(), 
                RoomId = roomDetails.Id

            };
            return View(dvm);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Detail(int? id)
        //{
        //    return View();
        //}
    }
}
