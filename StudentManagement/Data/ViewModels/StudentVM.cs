using StudentManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.ViewModels
{
    public class StudentVM
    {
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z-.]+$", ErrorMessage = "Only alpha is allowed")]
        public string Name { get; set; }
        [Range(12,12)]
        public int Standard { get; set; }
        [Range(2023, 2023, ErrorMessage = "Please enter a valid year")]
        public int AcademicYear { get; set; }
        [RegularExpression(@"[F-M]", ErrorMessage = "Enter valid character")]
        public string Gender { get; set; }

        
    }

    public class StudentWithTermAndMarkVM
    {
        internal ILogger<Student> _logger;

        public string Name { get; set; }
        public int Standard { get; set; }
        public int AcademicYear { get; set; }
        public string Gender { get; set; }

       
    }



}
