using HotelManagement.Models;
using HotelManagement.Models.DAL;
using HotelManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelDbContext _db;
        public HomeController(HotelDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()
		{
          
            var vm = new HomeIndexViewModel()
            {
                Sliders = await _db.Slider.Where(x => !x.IsDeleted).OrderBy(r=>r.Order).ToListAsync(),

                //  SearchBar = await _db.SearchBar.Where(d => !d.IsDeleted).Where(a => a.IsActive).Take(4).ToListAsync(),

                 ServiceList = await _db.Services.Take(4).ToListAsync(),

                Hotels = await _db.Hotels.ToListAsync(),

                Rooms = await _db.Rooms.ToListAsync()



        };
            return View(vm);
           
		}
      
      

       
    }
}
