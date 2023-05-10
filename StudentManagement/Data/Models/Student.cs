using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Data.Models
{
   
    public class Student
    {
        
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Standard { get; set; }
        public int AcademicYear { get;set; }
        public string Gender { get; set; }

       



    }


}
