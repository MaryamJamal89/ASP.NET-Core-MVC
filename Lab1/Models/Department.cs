using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            Courses = new HashSet<Course>();
        }           

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Remote("CheckId", "Department", ErrorMessage = "Id is Already Exists")]
        [Range(000, 999, ErrorMessage = "Id 000-999 only")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter department name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter department location")]
        public string Location { get; set; }

        //One to Many Relation
        public virtual ICollection<Student> Students { get; set; }

        //Many to many Relation
        public virtual ICollection<Course> Courses { get; set; }
    }
}
