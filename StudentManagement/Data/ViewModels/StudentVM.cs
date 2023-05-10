using StudentManagement.Data.Models;

namespace StudentManagement.Data.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Standard { get; set; }
        public int AcademicYear { get; set; }
        public string Gender { get; set; }

        
    }

    public class StudentWithTermAndMarkVM
    {
        
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Standard { get; set; }
        public int AcademicYear { get; set; }
        public string Gender { get; set; }

       
    }



}
