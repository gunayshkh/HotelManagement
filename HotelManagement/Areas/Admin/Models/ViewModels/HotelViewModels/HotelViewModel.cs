using HotelManagement.Models.Entities;
using System.Collections.Generic;

namespace HotelManagement.Areas.Admin.Models.ViewModels.HotelViewModels
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public byte StarCount { get; set; }
        public ICollection<Room> Rooms { get; set; }




       
    }
}
