using Allup.Models.Entities;

namespace HotelManagement.Models.Entities
{
    public class ActiveAccomodation : BaseEntity
    {
        public int? AccomodationId { get; set; }
        public Accomodation Accomodation { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }

    }
}
