using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.Models
{
   
    public class Student
    {
        [Range(6000, int.MaxValue, ErrorMessage = "Enter valid Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [RegularExpression(@"^[a-zA-Z-.]+$",ErrorMessage ="Only alpha is allowed")]
        public string Name { get; set; }
        [Range(12,12)]
        public int Standard { get; set; }
        [Range(2023, 2023, ErrorMessage = "Please enter  valid year")]
        public int AcademicYear { get;set; }
        [RegularExpression(@"[F-M]", ErrorMessage = "Enter valid character")]
        public string Gender { get; set; }

          

     

    }


}
