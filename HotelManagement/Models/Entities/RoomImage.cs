using Allup.Models.Entities;

namespace HotelManagement.Models.Entities
{
    public class RoomImage :BaseEntity
    {
        public string  ImageURL { get; set; }
        public bool  IsMain { get; set; } = false;
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
