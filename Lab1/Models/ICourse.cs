namespace Lab1.Models
{
    public interface ICourse
    {
        public IEnumerable<Course> AllICourses();
        public Course Display(string id);
        public void Create(Course course);
        public void Delete(Course course);
        public void Update(Course newcrs, string id);

        public IEnumerable<Course> GetDeptCourses(string id);
        public void removeDeptCourse(string id, string courseID);
        public void addDeptCourse(string id, string courseID);
    }
}
