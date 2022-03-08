
using Allup.Models.Entities;
using System.Collections.Generic;

namespace HotelManagement.Models.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set;}
        public double StarCount { get; set; }
        public string Description { get; set;}
        public string ImageURL { get; set; }
        public string ContactInformation { get; set; }
        public string Address { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public int? TypeId { get; set; }
        public HotelType HotelType { get; set; }


    }
}
