using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.Entities
{
    public class User: IdentityUser
    {
        [Required]
        public string FullName { get; set; }

		public ICollection<Accomodation> Accomodations { get; set; }
	}
}
