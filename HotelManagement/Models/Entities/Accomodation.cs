using Allup.Models.Entities;
using System;

namespace HotelManagement.Models.Entities
{
    public class Accomodation : BaseEntity
    {
     

        public string FullName { get; set; }

        public int UserId { get; set; }
		public User User { get; set; }
		public string ContactInfo { get; set; }
        public string Email { get; set; }

    
        public int? RoomId { get; set; }
        public Room Room { get; set; }

        

        public double FeePerNight { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public bool IsActive { get; set; }


    }
}
