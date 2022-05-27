namespace Lab1.Models
{
    public class CourseDepartment
    {
        public IEnumerable<Course> CourseInDpt { get; set; }
        public IEnumerable<Course> CourseNotInDpt { get; set; }
        public Department Department { get; set; }
    }
}
