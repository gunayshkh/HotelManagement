using HotelManagement.Models.Entities;
using System;
using System.Collections.Generic;

namespace HotelManagement.Models.ViewModels
{
	public class RoomSearchViewModel
	{
		public DateTime CheckIn { get; set; }
		public DateTime CheckOut { get; set; }
		public int AdultsCount { get; set; }
		public int ChildCount { get; set; }
		



	}
}
