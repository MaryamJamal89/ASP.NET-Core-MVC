using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class Course
    {
        public Course()
        {
            Departments = new HashSet<Department>();
            studentCourses = new HashSet<StudentCourse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Remote("CheckId", "Course", ErrorMessage = "Id is Already Exists")]
        [Range(000, 999, ErrorMessage = "Id 000-999 only")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter course name")]
        public string Name { get; set; }

        //Many to Many Relation
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<StudentCourse> studentCourses { get; set; }

    }
}
