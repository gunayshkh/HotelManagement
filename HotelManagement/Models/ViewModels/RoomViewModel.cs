using HotelManagement.Models.Entities;
 using System.Collections.Generic;

namespace HotelManagement.Models.ViewModels
{
    public class RoomViewModel
    {
        public string RoomNo { get; set; }
        public string RoomImage { get; set; }
        public decimal RoomPrice { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
        public bool IsActive { get; set; }

        public int HotelId { get; set; }
    }
}
