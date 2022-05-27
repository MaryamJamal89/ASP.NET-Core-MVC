using Microsoft.AspNetCore.Mvc;
using Lab1.Data;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class CourseController : Controller
    {
        ICourse db;
        public CourseController(ICourse _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();

            IEnumerable<Course> allCourses = db.AllICourses();
            return View(allCourses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Create(course);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(String id)
        {
            Course course = db.Display(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Update(Course course, string id)
        {
            if (ModelState.IsValid)
            {
                db.Update(course, id);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Display(string id)
        {
            Course course = db.Display(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            Course course = db.Display(id);
            db.Delete(course);

            return RedirectToAction("Index");
        }

        public IActionResult CheckId(string Id)
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();

            Course course = db.Display(Id);

            if (course == null)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
