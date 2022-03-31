using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Areas.Admin.Models.ViewModels.HotelViewModels
{
    public class CreateHoteViewModel
    {
        [Required(ErrorMessage ="Insert a name")]
           //Display("Hotel Name")]

        public string Name { get; set; }
        [Required(ErrorMessage ="Add a description about hotel"),
         MinLength(50, ErrorMessage = "Min text size is 50 characters"),
            MaxLength(200, ErrorMessage = "The text word count cannot exceed 200 characters")]
        public string  Description { get; set; }
        [Required(ErrorMessage ="Select a picture to add")]
        public IFormFile ImageURL { get; set; }
        [Required(ErrorMessage ="The star count is not selected")]
        public double  StarCount { get; set; }
    }
}
