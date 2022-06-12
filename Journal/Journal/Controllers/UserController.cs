using Microsoft.AspNetCore.Mvc;

namespace Journal.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
