using HotelManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.ViewModels
{
	public class AccomodationViewModel
	{

        public string FullName { get; set; }
        public int UserId { get; set; }
        
        public string ContactInfo { get; set; }
        public string Email { get; set; }


        public double FeePerNight { get; set; }
        [Required]
        public DateTime Checkin { get; set; }
        [Required]
        public DateTime Checkout { get; set; }
        public bool IsActive { get; set; }

     
    }
}
