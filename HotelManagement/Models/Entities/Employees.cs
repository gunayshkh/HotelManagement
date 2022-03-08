using Allup.Models.Entities;

namespace HotelManagement.Models.Entities
{
    public class Employees : BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }


    }
}
