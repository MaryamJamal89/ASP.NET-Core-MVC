using Lab1.Data;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        IStudent db;
        IDepartment department;
        public StudentController(IStudent _db, IDepartment _department)
        {
            db = _db;
            department = _department;
        }

        public IActionResult Index(String serchedname)
        {
            //ASPCoreMVCDbContext db = new ASPCoreMVCDbContext();
            IEnumerable<Student> allStudents;

            //return View(db.GetAllStydents);

            if (serchedname == String.Empty || serchedname == null)
            {
                allStudents = db.AllStudents();
            }
            else

            {
                allStudents = db.AllStudents().Where(a => a.Name.ToLower().Contains(serchedname.ToLower()));
                //allStudents = db.AllStudents().Where(a => a.Name.ToLower().StartsWith(serchedname.ToLower()));
            }

            return View(allStudents);
        }

        // HTTP GET VERSION
        [HttpGet]
        public IActionResult Create()
        {
            //ASPCoreMVCDbContext db = new ASPCoreMVCDbContext();
            SelectList depts = new SelectList(department.AllDepartments(), "Id", "Name");
            ViewBag.depts = depts;

            return View();
        }
        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Student student)
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();
            SelectList depts = new SelectList(department.AllDepartments(), "Id", "Name");
            ViewBag.depts = depts;

            if (ModelState.IsValid)
            {
                db.Create(student);
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();
            Student student = db.Display(id);
            SelectList depts = new SelectList(department.AllDepartments(), "Id", "Name");
            ViewBag.depts = depts;
            return View(student);

            //Student student = StudentMoc.AllStudents.Where(s => s.Id == stdname).FirstOrDefault();
            //return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student, string id)
        {
            if (ModelState.IsValid)
            {
                //StudentMoc.AllStudents.Where(e => e.Id == stdname).FirstOrDefault().Email = student.Email;
                //StudentMoc.AllStudents.Where(e => e.Id == stdname).FirstOrDefault().Department = student.Department;
                //StudentMoc.AllStudents.Where(e => e.Id == stdname).FirstOrDefault().Age = student.Age;
                //StudentMoc.AllStudents.Where(e => e.Id == stdname).FirstOrDefault().Name = student.Name;
                //StudentMoc.AllStudents.Where(e => e.Id == stdname).FirstOrDefault().Id = student.Id;

                db.Update(student, id);
                return RedirectToAction("Index");
            }
            else
            {
                //var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                //return Content($"{message}");

                //ASPCoreMVCDbContext db = new ASPCoreMVCDbContext();
                SelectList depts = new SelectList(department.AllDepartments(), "Id", "Name");
                ViewBag.depts = depts;
                return View(student);
            }
        }

        [HttpGet]
        public IActionResult Display(string id)
        {
            Student student = db.Display(id);
            return View(student);

            //Student student = StudentMoc.AllStudents.Where(s => s.Id == stdname).FirstOrDefault();
            //return View(student);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            //TODO: alert
            Student student = db.Display(id);
            db.Delete(student);

            //Student student = StudentMoc.AllStudents.Where(s => s.Id == stdname).FirstOrDefault();
            //StudentMoc.Delete(student);

            return RedirectToAction("Index");
        }

        public IActionResult CheckEmail(string Email, string id)
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();

            //Student student = db.AllStudents().FirstOrDefault(a => a.Email == Email);
            Student student = db.AllStudents().FirstOrDefault(s => s.Email == Email);
            Student studentId = db.Display(id);

            if (student == null || studentId == student)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult CheckId(string Id)
        {
            //ASPCoreMVCDbContext myDb = new ASPCoreMVCDbContext();

            //Student student = db.AllStudents().FirstOrDefault(a => a.Email == Email);
            Student student = db.Display(Id);

            if (student == null)
            {
                return Json(true);
            }
            return Json(false);
        }

        [HttpGet]
        public IActionResult Courses(string id)
        {
            Student student = db.AllStudents().FirstOrDefault(a => a.Id == id);
            return View(student.studentCourses);
        }
        [HttpPost]
        public IActionResult Courses(int[] degree, string id, string[] courseId)
        {
            Student student = db.AllStudents().FirstOrDefault(a => a.Id == id);

            if (ModelState.IsValid)
            {
                db.UpdateDgree(degree, id, courseId);
                return RedirectToAction("Index");
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Content($"{message}");

                //ASPCoreMVCDbContext db = new ASPCoreMVCDbContext();

                return View(student.studentCourses);
            }
        }
    }
}
