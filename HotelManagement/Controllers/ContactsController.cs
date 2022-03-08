using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
