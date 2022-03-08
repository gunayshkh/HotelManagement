using Allup.Models.Entities;
using System.Collections;
using System.Collections.Generic;

namespace HotelManagement.Models.Entities
{
    public class Room : BaseEntity
    {
        
        public string RoomNo { get; set; }
        public string RoomImage { get; set; }
        public double RoomPrice { get; set; }
        public int? RoomTypeId { get; set; }
        
        public ICollection<RoomImage> Images { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomArea { get; set; }
        public string RoomDescription { get; set; }
        public bool IsActive { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int? HotelTypeId { get; set; }

        public HotelType HotelType { get; set; }

		public int ChildCount { get; set; }
		public int AdultCount { get; set; }

		public ICollection<Accomodation> Accomodations { get; set; }


	}

   
}
