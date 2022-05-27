using Lab1.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Models
{
    public class DepartmentMoc : IDepartment
    {
        ASPCoreMVCDbContext db;// = new ASPCoreMVCDbContext();
        public DepartmentMoc(ASPCoreMVCDbContext _db)
        {
            db = _db;
        }

        //private List<Department> allDepartments = new List<Department>() 
        //{
        //    new Department() { Id = "1", Name = "Development", Location = "Cairo" },
        //    new Department() { Id = "2", Name = "HR", Location = "Mansoura" },
        //    new Department() { Id = "3", Name = "Research", Location = "Alex" },
        //};

        public IEnumerable<Department> AllDepartments()
        {
            return db.Departments.ToList();

            //return allDepartments;
        }

        public Department Display(string id)
        {
            return db.Departments.FirstOrDefault(d => d.Id == id);

            //return allDepartments.FirstOrDefault(d => d.Id == id);
        }

        public void Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();

            //allDepartments.Add(department);
        }

        public void Update(Department newdept, string id)
        {
            Department olddept = db.Departments.FirstOrDefault(d => d.Id == id);

            olddept.Id = newdept.Id;
            olddept.Name = newdept.Name;
            olddept.Location = newdept.Location;
            db.SaveChanges();
        }

        public void Delete(Department department)
        {
            db.Departments.Remove(department);
            db.SaveChanges();
        }
    }
}
