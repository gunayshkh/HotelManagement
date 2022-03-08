using HotelManagement.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelManagement.Models.DAL
{
    public class HotelDbContext : IdentityDbContext<User>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
            public DbSet<Employees> Employees { get; set; }
            public DbSet<Accomodation> Accomodations { get; set; }
            public DbSet<Hotel> Hotels { get; set; }

            public DbSet<Room> Rooms { get; set; }
            public DbSet<RoomType> RoomTypes { get; set; }
            public DbSet<ActiveAccomodation> ActiveAccomodations { get; set; }
            public DbSet<Services> Services { get; set; }
            public DbSet<HotelType> HotelTypes { get; set; }
            public DbSet<User> Users { get; set; }
            
	    	public DbSet<Slider> Slider { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
       public DbSet<RoomImage> RoomImages { get; set; }
        // public IEnumerable<object> Slider { get; internal set; }
    }

}
