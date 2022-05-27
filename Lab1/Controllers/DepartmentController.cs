using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartment db;
        ICourse course;

        public DepartmentController(IDepartment _db, ICourse _course)
        {
            db = _db;
            course = _course;
        }

        public IActionResult Index()
        {
            //ASPCoreMVCDbContext db = new ASPCoreMVCDbContext();

            IEnumerable<Department> allDepartments = db.AllDepartments();
            //IEnumerable<Department> allDepartments = db.AllDepartments();

            return View(allDepartments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Create(department);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(String id)
        {
            Department department = db.Display(id);
            return View(department);
        }        
        [HttpPost]
        public IActionResult Update(Department department, string id)
        {
            if (ModelState.IsValid)
            {
                db.Update(department, id);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Display(string id)
        {
            Department department = db.Display(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            Department department = db.Display(id);
            db.Delete(department);

            return RedirectToAction("Index");
        }

        public IActionResult CheckId(string Id)
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();

            Department department = db.Display(Id);

            if (department == null)
            {
                return Json(true);
            }
            return Json(false);
        }     
        
        public IActionResult Courses(string id)
        {
            Department department = db.Display(id);
            IEnumerable<Course> lstcourse = course.GetDeptCourses(id);
            IEnumerable<Course> lstnotcourse = course.AllICourses().Except(lstcourse);
            CourseDepartment cd = new CourseDepartment()
            {
                CourseInDpt = lstcourse,
                CourseNotInDpt = lstnotcourse,
                Department = department
            };
            return View(cd);
        }

        public IActionResult updateDept(string deptId, string[] InCourse, string[] NotInCourse)
        {
            foreach (var i in InCourse)
            {
                course.removeDeptCourse(deptId, i);
            }
            foreach (var i in NotInCourse)
            {
                course.addDeptCourse(deptId, i);
            }
            return RedirectToAction("Index");
        }
    }
}
