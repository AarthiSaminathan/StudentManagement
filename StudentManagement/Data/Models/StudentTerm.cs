namespace StudentManagement.Data.Models
{
    public class StudentTerm
    {
        public int Id { get; set; } 
        
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TermId { get; set; }
        public Term Term { get; set; }  
    }
}
