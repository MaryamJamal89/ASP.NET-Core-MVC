using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class StudentCourse
    {
        [ForeignKey("student")]
        public string StdId { get; set; }
        public Student student { get; set; }


        [ForeignKey("course")]
        public string CourseId { get; set; }
        public Course course { get; set; }

        [Range(0, 100, ErrorMessage = "Invalid, Degree between 0 and 100")]
        public int? Degree { get; set; }
    }
}
