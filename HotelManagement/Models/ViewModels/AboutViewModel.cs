using HotelManagement.Models.Entities;
using System.Collections.Generic;

namespace HotelManagement.Models.ViewModels
{
    public class AboutViewModel
    {
        public List<Employees> Team { get; set; }
        public Employees CEO { get; set; }
        public List<Services> Services { get; set; }
    }
}
