using Lab1.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Models
{
    public class CourseMoc : ICourse
    {
        ASPCoreMVCDbContext db;// = new ASPCoreMVCDbContext();
        public CourseMoc(ASPCoreMVCDbContext _db)
        {
            db = _db;
        }

        public void addDeptCourse(string id, string courseID)
        {
            Department dept = db.Departments.Include(a => a.Courses).Include(b => b.Students).ThenInclude(c => c.studentCourses).FirstOrDefault(a => a.Id == id);
            foreach (var i in dept.Students)
            {
                i.studentCourses.Add(
                new StudentCourse()
                {
                    CourseId = courseID,
                    StdId = i.Id,
                });
            }
            dept.Courses.Add(db.Courses.FirstOrDefault(b => b.Id == courseID));
            db.SaveChanges();
        }

        public IEnumerable<Course> AllICourses()
        {
            return (IEnumerable<Course>)db.Courses.ToList();
        }

        public void Create(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void Delete(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public Course Display(string id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetDeptCourses(string id)
        {
            return db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.Id == id).Courses;
        }

        public void removeDeptCourse(string id, string courseID)
        {
            Department dept = db.Departments.Include(a => a.Courses).Include(b => b.Students).ThenInclude(c => c.studentCourses).FirstOrDefault(a => a.Id == id);
            foreach (var i in dept.Students)
            {
                i.studentCourses.Remove(i.studentCourses.FirstOrDefault(a => a.CourseId == courseID));
            }
            dept.Courses.Remove(db.Courses.FirstOrDefault(b => b.Id == courseID));
            db.SaveChanges();
        }

        public void Update(Course newcrs, string id)
        {
            Course oldcrs = db.Courses.FirstOrDefault(c => c.Id == id);

            oldcrs.Id = newcrs.Id;
            oldcrs.Name = newcrs.Name;
            db.SaveChanges();
        }
    }
}
