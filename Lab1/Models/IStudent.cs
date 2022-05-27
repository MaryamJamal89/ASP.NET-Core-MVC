namespace Lab1.Models
{
    public interface IStudent
    {
        public IEnumerable<Student> AllStudents();
        public Student Display(string id);
        public void Create(Student student);
        public void Delete(Student student);
        public void Update(Student newStd, string id);
        public void UpdateDgree(int[] degree, string id, string[] courseId);
    }
}
