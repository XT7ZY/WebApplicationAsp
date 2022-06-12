using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Journal.Core;

namespace Journal.Controllers
{
    public class ScoreBoardController : Controller
    {


        [Authorize(Roles = $"{Constants.Roles.Student}")]
        public IActionResult IndexStudent()
        {
            return View();
        }
    }
}
