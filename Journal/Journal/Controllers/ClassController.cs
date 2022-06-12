using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Journal.Areas.Identity.Data;
using Journal.Core;
using Journal.Models;
using Journal.ViewModels;

namespace Journal.Controllers
{

    public class ClassController : Controller
    {

        private readonly ApplicatoinDbContext _db;

        public ClassController(ApplicatoinDbContext db)
        {
            _db = db;
        }


        [Authorize(Roles = $"{Constants.Roles.Administrator}")]
        public IActionResult Index()
        {
            ClassIndexViewModel viewModel = new ClassIndexViewModel()
            {
                Classes = _db.Classes.ToList(),
                Teachers = _db.Teachers.ToList(),
            };

            return View(viewModel);
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}")]
        public IActionResult Create()
        {
            ClassIndexViewModel viewModel = new ClassIndexViewModel()
            {
                Classes = _db.Classes.ToList(),
                Teachers = _db.Teachers.ToList(),
            };
            
            foreach (var item in viewModel.Teachers)
            {
                item.FullName = item.LastName + " " + item.Name + " " + item.SurName;
            }


            return View(viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassIndexViewModel obj)
        {
            
            _db.Classes.Add(obj.Class);
            _db.SaveChanges();

            return RedirectToAction("Index"); 

        }
    }
}
