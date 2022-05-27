using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class Student
    {
        public Student()
        {
            studentCourses = new HashSet<StudentCourse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Remote("CheckId", "Student", ErrorMessage = "Id is Already Exists")]
        //[Range(000, 999, ErrorMessage = "Invalid, Id 000-999 only")]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Range(15, 28, ErrorMessage = "Invalid, Age between 15 and 28")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"[_A-Za-z0-9-.]+@[A-Za-z]+\.[A-Za-z]{2,3}", ErrorMessage = "Invalid Email")]
        [Remote("CheckEmail", "Student", AdditionalFields = "Id", ErrorMessage = "Email is Already Exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be more than 6 digits")]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        //One to Many Relation (Navigation Prop)
        [ForeignKey("Department")]
        public string DepartmentId { get; set; }
        //[Required(ErrorMessage = "Please Choose your department")]
        public virtual Department? Department { get; set; }
        public virtual ICollection<StudentCourse> studentCourses { get; set; }
    }
}
