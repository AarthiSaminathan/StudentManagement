namespace StudentManagement.Data.Models
{
    public class Term
    {
        public int Id { get; set; }
        public string TermName { get; set; }

        public List<StudentTerm> StudentTerms { get; set; }
        public List<Mark> Marks { get; set; }
        public List<TermMark> TermMarks { get; internal set; }
    }
}
