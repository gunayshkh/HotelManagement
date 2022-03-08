using HotelManagement.Models.Entities;
using System.Collections.Generic;

namespace HotelManagement.Models.ViewModels
{
	public class HomeIndexViewModel
	{
		
		public RoomViewModel SearchBar { get; set; }
		public List<Slider> Sliders { get; set; }
		public List<Services> ServiceList { get; set; }
		public List<Hotel> Hotels { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
