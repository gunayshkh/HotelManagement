using HotelManagement.Models.Entities;
using System.Collections.Generic;

namespace HotelManagement.Models.ViewModels
{
    public class DetailViewModel
    {
        public int RoomId { get; set; }
        public Room Rooms { get; set; }

        public List<Services> Services { get; set; }
        public List<RoomImage> Images { get; set; }


        public RoomImage MainImage { get; set; }

        public List<Amenities> Amenities { get; set; }
        public AccomodationViewModel avm { get; set; }


    }
}
