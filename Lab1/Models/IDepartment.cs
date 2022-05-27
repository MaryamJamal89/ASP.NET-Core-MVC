namespace Lab1.Models
{
    public interface IDepartment
    {
        public IEnumerable<Department> AllDepartments();
        public Department Display(string id);
        public void Create(Department department);
        public void Delete(Department department);
        public void Update(Department newdept, string id);
    }
}
