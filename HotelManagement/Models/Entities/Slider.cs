using Allup.Models.Entities;

namespace HotelManagement.Models.Entities
{
	public class Slider: BaseEntity
	{
		public string ImageURL { get; set; }
		public int Order { get; set; }
	}
}
