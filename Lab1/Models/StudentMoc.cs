using Lab1.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Models
{
    public class StudentMoc : IStudent
    {
        ASPCoreMVCDbContext db;// = new ASPCoreMVCDbContext();
        public StudentMoc(ASPCoreMVCDbContext _db)
        {
            db = _db;
        }

        //private static List<Student> allStudents = new List<Student>();
        //public static IEnumerable<Student> AllStudents
        //{
        //    get { return allStudents; }
        //}

        public IEnumerable<Student> AllStudents()
        {
            return db.Students
                .Include(a => a.Department)
                .ThenInclude(d => d.Courses)
                .Include(b => b.studentCourses)
                .ThenInclude(c => c.course)
                .ToList();
        }

        public Student Display(string id)
        {
            return AllStudents().FirstOrDefault(s => s.Id == id);
        }

        public void Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void Delete(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public void Update(Student newStd, string id)
        {
            Student oldStd = db.Students.FirstOrDefault(s => s.Id == id);

            oldStd.Name = newStd.Name;
            oldStd.Age = newStd.Age;
            oldStd.Email = newStd.Email;
            oldStd.DepartmentId = newStd.DepartmentId;
            oldStd.Password = oldStd.Password;
            oldStd.ConfirmPassword = oldStd.ConfirmPassword;
            db.SaveChanges();
        }

        public void UpdateDgree(int[] degree, string id, string[] courseId)
        {
            Student oldStd = Display(id);
            for (int i = 0; i < degree.Length; i++)
            {
                oldStd.studentCourses.FirstOrDefault(a => a.CourseId == courseId[i]).Degree = degree[i];
            }
            db.SaveChanges();
        }
    }
}
