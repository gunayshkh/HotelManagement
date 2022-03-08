using HotelManagement.Models.Entities;
using System.Collections.Generic;

namespace HotelManagement.Models.ViewModels
{
    public class HotelIndexViewModel
    {
        public List<Hotel> Hotels { get; set; }
        public List<HotelType> HotelTypes { get; set; }

    }
}
