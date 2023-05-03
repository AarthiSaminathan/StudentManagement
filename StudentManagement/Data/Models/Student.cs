namespace StudentManagement.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public string Section { get; set; }
        public int AcademicYear { get;set; }
        public string Gender { get; set; }

        public List<StudentTerm> StudentTerms { get; set; }
        public List<Mark> Marks { get; set; }




    }


}
