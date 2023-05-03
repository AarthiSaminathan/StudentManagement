using StudentManagement.Data.Models;

namespace StudentManagement.Data.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public string Section { get; set; }
        public int AcademicYear { get; set; }
        public string Gender { get; set; }

        public List<int> MarkId{ get; set; }
        public int TermId { get; set; }
    }

    public class StudentWithTermAndMarkVM
    {
        
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public string Section { get; set; }
        public int AcademicYear { get; set; }
        public string Gender { get; set; }

        public List<Term> TermName { get; set; }
        public List<Mark> Marks { get; set; }
    }



}
